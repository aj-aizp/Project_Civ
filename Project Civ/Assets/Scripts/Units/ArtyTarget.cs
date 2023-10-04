using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtyTarget : MonoBehaviour
{

     private ArtyWeapon weapon;

    private Vector3 enemyPos; 

 
    public float radius = 100f; 


    private void Awake() {
        weapon = GetComponent<ArtyWeapon>();

    }
   

      void Update(){

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach (Collider2D hitCollider in hitColliders){

            if (hitCollider.TryGetComponent<EnemyAI>(out EnemyAI enemy)){

                if(enemy.getDeadState()==false) {
               enemyPos = enemy.transform.position;
               StartCoroutine(weapon.Fire(enemyPos));}


            }

           
        }


    }
 
}
