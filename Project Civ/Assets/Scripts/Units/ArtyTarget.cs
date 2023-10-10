using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArtyTarget : MonoBehaviour
{

     private ArtyWeapon weapon;

    private Vector3 targetPos; 

    private List<Vector3> enemyPosList; 

 
    public float radius = 100f; 


    private void Awake() {
        weapon = GetComponent<ArtyWeapon>();
        enemyPosList = new List<Vector3>(); 
    }
   

      void Update(){

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach (Collider2D hitCollider in hitColliders){

            if (hitCollider.TryGetComponent<EnemyAI>(out EnemyAI enemy)){

                if(enemy.getDeadState() == false) {  
                    enemyPosList.Add(enemy.transform.position); 
                }
            }
        }

        if(enemyPosList.Count >= 4) {
           targetPos = midPoint(enemyPosList); 
           StartCoroutine(weapon.Fire(targetPos)); 
        }

        else if (enemyPosList.Count != 0) {
            StartCoroutine(weapon.Fire(enemyPosList[0]));
        }

        enemyPosList.Clear();

    }


    private Vector3 midPoint(List<Vector3> enemyPosList) {
        float averageX = 0.0f; 
        float averageY = 0.0f; 

        foreach (Vector3 enemyPos in enemyPosList){
            averageX+= enemyPos.x; 
            averageY += enemyPos.y; 
        }

        averageX = averageX / enemyPosList.Count;

        averageY = averageY / enemyPosList.Count; 

        return new Vector3(averageX,averageY,0.0f); 
    }
 
}
