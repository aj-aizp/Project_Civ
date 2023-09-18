using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class TargetSystem : MonoBehaviour


{

    private WeaponController weapon;

    private Vector3 enemyPos; 

    private Transform enemyIn;

    private bool collision; 

    private void OnTriggerEnter2D(Collider2D col) {

    

        if (col.TryGetComponent<EnemyAI>(out EnemyAI enemy)) {
            collision = true;
            enemyIn = enemy.GetComponent<Transform>();
            enemyPos = enemy.transform.position;
        }
    }

    // private void OnTriggerExit2D(Collider2D other) {

    //  collision = false; 
  
    //  }


    private void Awake() {
        weapon = GetComponent<WeaponController>();

    }

    void Update(){

        if (collision) {
          enemyPos = enemyIn.position;
          StartCoroutine(weapon.Fire(enemyPos));
        }

    }
   
}
