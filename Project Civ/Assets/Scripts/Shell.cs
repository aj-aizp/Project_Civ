using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Shell : MonoBehaviour
{

  [SerializeField] AudioClip explosion; 

   private Animator animator; 

   private SpriteRenderer sprite; 
   public int bulletDamage = 100; 
   private EnemyAI enemy; 
   private Vector3 Traveldirection; 
   public float splashRange = 1f; 

   private AudioSource sound; 



   private void Awake() {
    sprite = GetComponent<SpriteRenderer>();
    sound = GetComponent<AudioSource>();
    animator = GetComponent<Animator>();
    sound.pitch = 1.5f;
   }

   public void setTravelDirection(Vector3 TravelDirection){
    this.Traveldirection = TravelDirection;
   }

   private void OnCollisionEnter2D(Collision2D col) {
    
    //sprite.enabled = false; 
    animator.Play("Explosion");
    sound.PlayOneShot(explosion); 

    if(splashRange >0) {

       Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position,splashRange);
        foreach(Collider2D hitCollider in hitColliders) {

            Vector3 forceVector = (Vector3) hitCollider.ClosestPoint(transform.position)-transform.position; 
            enemy = hitCollider.GetComponent<EnemyAI>();
            if (enemy!= null){
                enemy.damage(bulletDamage);
                enemy.setDamageVector(forceVector); 
            }
        }
    }

    // while(animator.GetCurrentAnimatorStateInfo(0).IsName("Explosion")){
    //     Debug.Log("Hello");
    //   //  sprite.enabled =false; 
    // }

    Destroy(gameObject,8f);

   }
}
