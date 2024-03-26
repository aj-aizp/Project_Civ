using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetSystem : MonoBehaviour
{
    private WeaponController weapon;
    private EnemyAI enemyAI; 

    private Vector3 enemyPos; 

 
    public float radius = 7f; 


    private void Awake() {
        weapon = GetComponent<WeaponController>();
        enemyAI = GetComponent<EnemyAI>();

    }

    void Update(){

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach (Collider2D hitCollider in hitColliders){

            if (hitCollider.TryGetComponent<SandBag> (out SandBag sand)) {

                enemyAI.setIsFiring(true); 

                enemyPos = sand.transform.position; 
                StartCoroutine(weapon.Fire(enemyPos));
            }

            if (hitCollider.TryGetComponent<UnionSol>(out UnionSol enemy)){

                enemyAI.setIsFiring(true);
            
               enemyPos = enemy.transform.position;
               StartCoroutine(weapon.Fire(enemyPos));
            }
        }
    }
}
