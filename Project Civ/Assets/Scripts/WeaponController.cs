using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

[SerializeField] GameObject bulletPrefab;
  private Transform gunPoint;
  private SpriteRenderer sprite; 

  private Animator animator;
  public float fireForce = 20f; 
  public float firerate; 
  private float nextfire;

  private UnityEngine.Vector3 aimVector;

  void Start() {

    gunPoint = transform.GetComponentInChildren<Transform>();

    sprite = transform.GetComponent<SpriteRenderer>();

    animator = transform.GetComponent<Animator>();

  }

  public IEnumerator Fire(UnityEngine.Vector3 targetPos){

   aimVector = targetPos - gunPoint.position;

   float rotationZ = Mathf.Atan2(aimVector.y, aimVector.x) *Mathf.Rad2Deg;
   aimVector = aimVector.normalized;

   //get absolute value of rotation. If greater than 90, flip on x axis. 
   if(Math.Abs(rotationZ) > 90f) {
    sprite.flipX = true;
   }
   else{
    sprite.flipX = false;
   }


  UnityEngine.Quaternion rotation = UnityEngine.Quaternion.Euler(0.0f,0.0f, rotationZ);


    if (Time.time > nextfire && animator.GetBool("isMoving") !=true) {
          nextfire = Time.time + firerate; 
          animator.SetBool("isShooting",true);
          GameObject bullet = Instantiate(bulletPrefab, gunPoint.position,rotation); 
          bullet.GetComponent<Rigidbody2D>().AddForce(aimVector * fireForce, ForceMode2D.Impulse);
          Destroy(bullet, 1.5f);             //Destroys bullet

          yield return new WaitForSeconds(.1f);
    }
    // else{
    //   animator.SetBool("isShooting",false); 
    // }
  
  }

}
