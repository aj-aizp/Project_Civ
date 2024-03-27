using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtyWeapon : MonoBehaviour
{
  [SerializeField] GameObject shellPrefab;
  [SerializeField] AudioClip mortarShot; 
  [SerializeField] UnionSol union; 
  [SerializeField] ArtyTarget targetSystem;  
  private int health = 150; 
  private AudioSource soundSource; 
  private Transform gunPoint; 
  private SpriteRenderer sprite; 
  private Animator animator; 
  public float shotForce; 
  public float fireRate;
  private float nextfire;
  private float randomNum; 
  private int deadLayer; 

  private UnityEngine.Vector3 aimVector; 

  void Start() {

    gunPoint = transform.GetComponentInChildren<Transform>();

    sprite = transform.GetComponent<SpriteRenderer>();

    animator = transform.GetComponent<Animator>();

    soundSource = transform.GetComponent<AudioSource>();
     deadLayer = LayerMask.NameToLayer("DeadBodies");

  }

     private void Death(){
      gameObject.layer = deadLayer;
      union.disableMove(); 
      union.setDeathState(true); 
      targetSystem.enabled = false; 
     // unionAnim.enabled = false; 
      enabled = false;
      transform.rotation = Quaternion.Euler(0,0,90);
      Destroy(gameObject,1f);
   }
  private void Update() {
    if (health<=0) {
      Death(); 
    }
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

  //  get absolute value of rotation. If greater than 90, flip on x axis. 
   if(Math.Abs(rotationZ1) > 90f) {
    sprite.flipX = true;
   }
   else{
    sprite.flipX = false;
   }


  UnityEngine.Quaternion rotation = UnityEngine.Quaternion.Euler(0.0f,0.0f, rotationZ2);


    if (Time.time > nextfire) {

          float randomNum2 = UnityEngine.Random.Range(0.0f,1f);
          nextfire = Time.time + fireRate + randomNum2; 

          animator.Play("Arty_Fire",0,1f);
          soundSource.PlayOneShot(mortarShot);
          GameObject shell = Instantiate(shellPrefab, gunPoint.position,rotation); 

          if(shell.TryGetComponent<Shell>(out Shell unionShell )) {
          unionShell.setTravelDirection(aimVector);
          unionShell.setTargtPoint(targetPos); 
          }
          else{
            shell.GetComponent<EnemyBullet>().setTravelDirection(aimVector);
          }


          shell.GetComponent<Rigidbody2D>().AddForce(aimVector * shotForce, ForceMode2D.Impulse);
          Destroy(shell, 10f);             //Destroys shell

          yield return new WaitForSeconds(.1f);
    }
  
  }


  void OnCollisionEnter2D(Collision2D col) {

    if(col.gameObject.GetComponent<EnemyBullet>() !=null) {
      health-=10; 
    }
  }


}
