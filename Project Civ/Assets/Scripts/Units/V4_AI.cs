using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Similar to all other Soldier AI scripts. Handles death and health stats.
*/
public class V4_AI : MonoBehaviour
{
    private UnionSol union;
    private Animator unionAnim;
    private V4_Target_System targetSystem;

    private V4_Weapon_Con weapon;

    private DamageFlash flash;

    private int health;

    private int deadLayer;

    private Rigidbody2D rb;

    private Vector3 damageVector;

    //grab all neccessary components. This most likely can be optimized
    private void Awake()
    {
        health = 100;
        flash = GetComponent<DamageFlash>();
        unionAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        targetSystem = GetComponent<V4_Target_System>();
        deadLayer = LayerMask.NameToLayer("DeadBodies");
        union = GetComponent<UnionSol>();
        union.setSoldierType(2);
        union.setDeathState(false);
    }

    public void setDamageVector(Vector3 damageVector)
    {
        this.damageVector = damageVector;
    }

    private void Death()
    {
        StartCoroutine(deathVelocity(new Vector2(damageVector.x, damageVector.y)));
        gameObject.layer = deadLayer;
        union.disableMove();
        union.setDeathState(true);
        targetSystem.enabled = false;
        unionAnim.enabled = false;
        enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, 90);
        Destroy(gameObject, 5f);
    }

    public void Damage(int damage)
    {
        this.health -= damage;
        flash.CallDamageFlash();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    //Death pushback vector velocity. Vector info comes from bullet that killed the unit
    public IEnumerator deathVelocity(Vector2 deathVector)
    {
        rb.velocity = deathVector * 3f;

        yield return new WaitForSeconds(.3f);

        rb.velocity = new Vector2(0f, 0f);

        yield return null;
    }
}
