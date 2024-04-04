using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Machine Gunner Firing script
*/
public class MachineGunner_Weapon : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    AudioClip gunShot;
    private AudioSource soundSource;
    private Transform gunPoint;
    private SpriteRenderer sprite;

    private Animator animator;
    public float fireForce = 20f;
    public float firerate;
    private float nextfire;

    private float randomNum;
    private Vector3 aimVector;

    private Vector3 aimPoint;

    void Awake()
    {
        sprite = transform.GetComponent<SpriteRenderer>();

        animator = transform.GetComponent<Animator>();

        soundSource = transform.GetComponent<AudioSource>();

        gunPoint = gameObject.transform.Find("GunPoint").transform;
    }

    //Fire Coroutine
    public IEnumerator Fire(Vector3 targetPos)
    {
        aimVector = targetPos - gunPoint.transform.position;

        float rotationZ1 = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;

        //add variation to bullet trajectory
        randomNum = UnityEngine.Random.Range(-.3f, .3f);
        aimVector.x = aimVector.x + randomNum;
        aimVector.y = aimVector.y + randomNum;

        float rotationZ2 = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
        aimVector = aimVector.normalized;
        //get absolute value of rotation. If greater than 90, flip sprite on x axis.
        if (Math.Abs(rotationZ1) < 90f)
        {
            sprite.flipX = true;
            // aimPoint = new Vector3 (-gunPoint.position.x,gunPoint.position.y,0);
        }
        else
        {
            sprite.flipX = false;
            //aimPoint = gunPoint.transform.position;
        }

        Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ2);

        if (Time.time > nextfire && isPlaying(animator, "MachineGunner_Moving") != true)
        {
            float randomNum2 = UnityEngine.Random.Range(0.0f, 0.05f);
            nextfire = Time.time + firerate + randomNum2;

            animator.Play("MachineGunner_Shooting", 0, 1f);
            soundSource.PlayOneShot(gunShot);
            GameObject bullet = Instantiate(bulletPrefab, gunPoint.transform.position, rotation);

            if (bullet.TryGetComponent<Bullet>(out Bullet unionBullet))
            {
                unionBullet.setTravelDirection(aimVector);
            }
            else
            {
                bullet.GetComponent<EnemyBullet>().setTravelDirection(aimVector);
            }

            bullet.GetComponent<Rigidbody2D>().AddForce(aimVector * fireForce, ForceMode2D.Impulse);
            Destroy(bullet, 1.5f); //Destroys bullet

            yield return new WaitForSeconds(.1f);
        }
    }

    //Checks if moving animation is playing
    private bool isPlaying(Animator anim, string stateName)
    {
        if (
            anim.GetCurrentAnimatorStateInfo(0).IsName(stateName)
            && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
