using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Bullet script for allied units
*/
public class Bullet : MonoBehaviour
{
    public int bulletDamage = 10;
    private EnemyAI enemy;
    private Vector3 Traveldirection;

    //travel direction set in respective weapon controllers
    public void setTravelDirection(Vector3 TravelDirection)
    {
        this.Traveldirection = TravelDirection;
    }

    //When bullet hits an enemy collider, send damage and travel direction data. Direction data used for death kickback effect
    private void OnCollisionEnter2D(Collision2D col)
    {
        enemy = col.gameObject.GetComponent<EnemyAI>();

        if (enemy != null)
        {
            enemy.damage(bulletDamage);
            enemy.setDamageVector(Traveldirection);
        }
        Destroy(gameObject);
    }
}
