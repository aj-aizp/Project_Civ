using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   public int bulletDamage = 10; 
   private UnionSol union; 
     private Vector3 Traveldirection;



   public void setTravelDirection(Vector3 TravelDirection){
    this.Traveldirection = TravelDirection;
   }

   private void OnCollisionEnter2D(Collision2D col) {

    union = col.gameObject.GetComponent<UnionSol>();

    if(union!=null){
        union.Damage(bulletDamage); 
        union.setDamageVector(Traveldirection);
    }
    Destroy(gameObject);

   }


}
