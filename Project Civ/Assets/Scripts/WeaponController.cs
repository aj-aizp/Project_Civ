using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

[SerializeField] GameObject bulletPrefab;
private Transform gunPoint;
  public float fireForce = 20f; 
  public float firerate; 
  private float nextfire;

  private UnityEngine.Vector3 aimVector;

  void Start() {

    gunPoint = transform.GetComponentInChildren<Transform>();
    
  }

  public IEnumerator Fire(UnityEngine.Vector3 targetPos){

   aimVector = targetPos - gunPoint.position;

   float rotationZ = Mathf.Atan2(aimVector.y, aimVector.x) *Mathf.Rad2Deg;
   aimVector = aimVector.normalized;

        // UnityEngine.Quaternion rotation = UnityEngine.Quaternion.LookRotation(aimVector - gunPoint.position);

        UnityEngine.Quaternion rotation = UnityEngine.Quaternion.Euler(0.0f,0.0f, rotationZ);


    if (Time.time > nextfire) {
        nextfire = Time.time + firerate; 

          GameObject bullet = Instantiate(bulletPrefab, gunPoint.position,rotation); 
          bullet.GetComponent<Rigidbody2D>().AddForce(aimVector * fireForce, ForceMode2D.Impulse);
          Destroy(bullet, 1f);             //Destroys bullet

          yield return new WaitForSeconds(.1f);
    }
  
  }

}
