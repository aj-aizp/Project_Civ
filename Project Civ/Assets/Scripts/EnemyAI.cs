using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private int enemyID;
    public int enemyHealth; 

    private Animator enemyAnim; 
    private EnemyTargetSystem weaponTarget;
    private Rigidbody2D rb; 

    private int deadLayer;

    private bool dead;

    private Vector3 DamageVector; 

    public void setDamageVector(Vector3 DamageVector){
        this.DamageVector = DamageVector;
    }

    public int getEnemyID() {
        return enemyID;
    }

    public void setEnemyID(int enemyID){
     enemyID = this.enemyID;
    }

    public bool getDeadState(){
        return dead;
    }

    public int getEnemyHealth (){
        return enemyHealth;
    }

    public void setEnemyHealth (int enemyHealth){
        this.enemyHealth = enemyHealth;
    }

    public void damage (int damage) {
        this.enemyHealth -=damage;
    }


    private void Awake() {
        enemyHealth = 100; 
        dead = false;
        enemyAnim = GetComponent<Animator>();
        weaponTarget = GetComponent<EnemyTargetSystem>();
        rb = GetComponent<Rigidbody2D>();
        deadLayer = LayerMask.NameToLayer("DeadBodies");
    }

//Sets Enabled to be false, which disables Update function from being called. Then rotates the object and then destroyed after delay. 
    private void Death(){
        StartCoroutine(deathVelocity(new Vector2(DamageVector.x,DamageVector.y)));
        gameObject.layer = deadLayer;
        dead = true;
        enemyAnim.enabled = false; 
        weaponTarget.enabled = false;
        enabled = false;
        transform.rotation = Quaternion.Euler(0,0,90);
       
        Destroy(gameObject,5f);
    }


   public IEnumerator deathVelocity(Vector2 deathVector){

    rb.velocity = deathVector *2f; 

    yield return new WaitForSeconds(.3f);

    rb.velocity = new Vector2 (0f,0f);

    yield return null;
   }

    private void Update() {
        if(enemyHealth <=0){
          Death(); 
        }
    }

    


}
