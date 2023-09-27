using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public int bulletDamage = 10; 
   private EnemyAI enemy; 

   private void OnCollisionEnter2D(Collision2D col) {

    enemy = col.gameObject.GetComponent<EnemyAI>();

    if(enemy!=null){
        enemy.damage(bulletDamage); 
    }
    Destroy(gameObject);

   }


}
