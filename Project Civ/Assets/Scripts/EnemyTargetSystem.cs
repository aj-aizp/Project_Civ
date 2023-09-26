using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetSystem : MonoBehaviour
{
    private WeaponController weapon;

    private Vector3 enemyPos; 

 
    public float radius = 3f; 


    private void Awake() {
        weapon = GetComponent<WeaponController>();

    }

    void Update(){

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach (Collider2D hitCollider in hitColliders){

            if (hitCollider.TryGetComponent<TargetSystem>(out TargetSystem enemy)){
            
               enemyPos = enemy.transform.position;
               StartCoroutine(weapon.Fire(enemyPos));
            }

           
        }


    }
}
