using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Numerics;
using UnityEngine;

/*
Shell script for Artillery unit. Kind of a more complicated version of the bullet scripts
*/
public class Shell : MonoBehaviour
{
    [SerializeField]
    AudioClip explosion;

    [SerializeField]
    GameObject explosionPrefab;

    private Shell shell;

    public float hitForce;
    private BoxCollider2D boxCol;

    private SpriteRenderer sprite;
    public int bulletDamage = 50;
    private EnemyAI enemy;
    private UnityEngine.Vector3 targetPoint;
    private UnityEngine.Vector3 Traveldirection;
    public float splashRange = 1f;

    private AudioSource sound;
    private Transform warHead;

    private void Awake()
    {
        shell = GetComponent<Shell>();
        sprite = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
        warHead = transform.GetComponentInChildren<Transform>();
        boxCol = GetComponent<BoxCollider2D>();
        sound.pitch = 1.5f;
    }

    public void setTravelDirection(UnityEngine.Vector3 TravelDirection)
    {
        this.Traveldirection = TravelDirection;
    }

    public void setTargtPoint(UnityEngine.Vector3 targetPoint)
    {
        this.targetPoint = targetPoint;
    }

    //When shell hits enemy unit. PLay sound effects and explosion animation. Does damage to all enemies within splash overlapCircle collider.
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject hitExplode = Instantiate(
            explosionPrefab,
            warHead.position,
            UnityEngine.Quaternion.identity
        );
        boxCol.enabled = false;
        sprite.enabled = false;

        sound.PlayOneShot(explosion);

        if (splashRange > 0)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRange);
            foreach (Collider2D hitCollider in hitColliders)
            {
                UnityEngine.Vector3 forceVector =
                    (UnityEngine.Vector3)hitCollider.ClosestPoint(transform.position) //force vector calculated is the vector from the center of hitCircle to the enemy hitpoint
                    - transform.position;
                enemy = hitCollider.GetComponent<EnemyAI>();
                if (enemy != null)
                {
                    enemy.damage(bulletDamage);
                    enemy.setDamageVector(forceVector * hitForce);
                }
            }
        }

        Destroy(hitExplode, 4f);
        Destroy(gameObject, 8f);
    }
}
