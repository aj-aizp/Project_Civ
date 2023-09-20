using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

[SerializeField] GameObject bulletPrefab;
[SerializeField] Transform gunPoint;
  public float fireForce = 20f; 
  public float firerate; 
  private float nextfire;

  private Vector3 aimVector;

  public IEnumerator Fire(Vector3 targetPos){

    aimVector = targetPos - gunPoint.position;

    if (Time.time > nextfire) {
        nextfire = Time.time + firerate; 

          GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation); 
          bullet.GetComponent<Rigidbody2D>().AddForce(aimVector * fireForce, ForceMode2D.Impulse);
          Destroy(bullet, 1f);             //Destroys bullet

          yield return new WaitForSeconds(.1f);
    }
  
  }

}
