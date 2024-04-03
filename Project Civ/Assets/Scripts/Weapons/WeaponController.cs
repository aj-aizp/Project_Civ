using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

 [SerializeField] GameObject bulletPrefab;
 [SerializeField] AudioClip gunShot; 
  private AudioSource soundSource;
  private Transform gunPoint;
  private SpriteRenderer sprite; 

  private Animator animator;
  public float fireForce = 20f; 
  public float firerate; 
  private float nextfire;

  private float randomNum; 

  private UnityEngine.Vector3 aimVector;

  void Start() {

    gunPoint = transform.GetComponentInChildren<Transform>();

    sprite = transform.GetComponent<SpriteRenderer>();

    animator = transform.GetComponent<Animator>();

    soundSource = transform.GetComponent<AudioSource>();

  }

  public IEnumerator Fire(UnityEngine.Vector3 targetPos){

   aimVector = targetPos - gunPoint.position;
  

   float rotationZ1 = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;

   //add variation to bullet trajectory
   randomNum = UnityEngine.Random.Range(-.3f,.3f); 
   aimVector.x = aimVector.x + randomNum;
   aimVector.y = aimVector.y + randomNum;

   float rotationZ2 = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
   aimVector = aimVector.normalized;

   //get absolute value of rotation. If greater than 90, flip sprite on x axis. 
   if(Math.Abs(rotationZ1) > 90f) {
    sprite.flipX = true;
   }
   else{
    sprite.flipX = false;
   }


  UnityEngine.Quaternion rotation = UnityEngine.Quaternion.Euler(0.0f,0.0f, rotationZ2);


    if (Time.time > nextfire && animator.GetBool("isMoving") !=true) {

          float randomNum2 = UnityEngine.Random.Range(0.0f,1f);
          nextfire = Time.time + firerate + randomNum2; 

          animator.Play("Union_Shoot", 0,1f);
          soundSource.PlayOneShot(gunShot);
          GameObject bullet = Instantiate(bulletPrefab, gunPoint.position,rotation); 

          if(bullet.TryGetComponent<Bullet>(out Bullet unionBullet )) {
          unionBullet.setTravelDirection(aimVector); }
          else{
            bullet.GetComponent<EnemyBullet>().setTravelDirection(aimVector);
          }

          

          bullet.GetComponent<Rigidbody2D>().AddForce(aimVector * fireForce, ForceMode2D.Impulse);
          Destroy(bullet, 1.5f);             //Destroys bullet

          yield return new WaitForSeconds(.1f);
    }
  
  }

}
