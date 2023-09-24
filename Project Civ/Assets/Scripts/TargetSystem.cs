using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TargetSystem : MonoBehaviour


{
    private WeaponController weapon;

    private Vector3 enemyPos; 

 
    public float radius = 50f; 


    private void Awake() {
        weapon = GetComponent<WeaponController>();

    }

    void Update(){

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach (Collider2D hitCollider in hitColliders){

            if (hitCollider.TryGetComponent<EnemyAI>(out EnemyAI enemy)){
               enemyPos = enemy.transform.position;
               StartCoroutine(weapon.Fire(enemyPos));
            }

           
        }


    }
   
}
