using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Shell : MonoBehaviour
{

  [SerializeField] AudioClip explosion; 
  [SerializeField] GameObject explosionPrefab; 

   private SpriteRenderer sprite; 
   public int bulletDamage = 100; 
   private EnemyAI enemy; 
   private Vector3 Traveldirection; 
   public float splashRange = 1f; 

   private AudioSource sound; 
   private Transform warHead; 



   private void Awake() {
    sprite = GetComponent<SpriteRenderer>();
    sound = GetComponent<AudioSource>();
    warHead = transform.GetComponentInChildren<Transform>();
    sound.pitch = 1.5f;
   }

   public void setTravelDirection(Vector3 TravelDirection){
    this.Traveldirection = TravelDirection;
   }

   private void OnCollisionEnter2D(Collision2D col) {



    GameObject hitExplode = Instantiate(explosionPrefab,warHead.position,Quaternion.identity);
    sprite.enabled = false; 
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

    Destroy(hitExplode,8f);
    Destroy(gameObject,8f);

   }
}
