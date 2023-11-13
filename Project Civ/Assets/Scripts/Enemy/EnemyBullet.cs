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

    if (union !=null) {
    int unionType = union.getSoldierType(); 
    switch(unionType){
      case 1: 
      col.gameObject.GetComponent<v1_AI>().Damage(bulletDamage); 
      col.gameObject.GetComponent<v1_AI>().setDamageVector(Traveldirection); 
      break;

      case 2: 
      col.gameObject.GetComponent<V4_AI>().Damage(bulletDamage); 
      col.gameObject.GetComponent<V4_AI>().setDamageVector(Traveldirection); 
      break; 
    }

}
    Destroy(gameObject);

   }


}
