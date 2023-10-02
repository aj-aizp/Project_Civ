using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Shell : MonoBehaviour
{

  [SerializeField] AudioClip explosion; 
   public int bulletDamage = 100; 
   private EnemyAI enemy; 
   private Vector3 Traveldirection; 
   public float splashRange = 1f; 

   private AudioSource sound; 



   private void Awake() {
    sound = GetComponent<AudioSource>();
    sound.pitch = 2f;
   }

   public void setTravelDirection(Vector3 TravelDirection){
    this.Traveldirection = TravelDirection;
   }

   private void OnCollisionEnter2D(Collision2D col) {

    sound.PlayOneShot(explosion); 

    if(splashRange >0) {

       Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position,splashRange);
        foreach(Collider2D hitCollider in hitColliders) {

           // Vector3 forceVector = transform.position -(Vector3) hitCollider.ClosestPoint(transform.position); 
            Vector3 forceVector = (Vector3) hitCollider.ClosestPoint(transform.position)-transform.position; 
            enemy = hitCollider.GetComponent<EnemyAI>();
            if (enemy!= null){
                enemy.damage(bulletDamage);
                enemy.setDamageVector(forceVector); 
            }
        }
    }

    Destroy(gameObject,5f);
    // enemy = col.gameObject.GetComponent<EnemyAI>();

    // if(enemy!=null){
    //     enemy.damage(bulletDamage); 
    //     enemy.setDamageVector(Traveldirection);
    // }
    // Destroy(gameObject);

   }
}
