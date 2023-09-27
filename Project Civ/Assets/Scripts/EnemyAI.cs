using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private int enemyID;
    public int enemyHealth; 

    private Animator enemyAnim; 

    public int getEnemyID() {
        return enemyID;
    }

    public void setEnemyID(int enemyID){
     enemyID = this.enemyID;
    }

    public int getEnemyHealth (){
        return enemyHealth;
    }

    public void setEnemyHealth (int enemyHealth){
        this.enemyHealth = enemyHealth;
    }

    public void damage (int damage) {
        this.enemyHealth -=damage;
    }


    private void Awake() {
        enemyHealth = 100; 
        enemyAnim = transform.GetComponent<Animator>();
    }

//Sets Enabled to be false, which disables Update function from being called. Then rotates the object and then destroyed after delay. 
    private void Death(){
        enemyAnim.enabled = false; 
        enabled = false;
        transform.rotation = Quaternion.Euler(0,0,90);
        Destroy(gameObject,5f);
    }

    private void Update() {
        if(enemyHealth <=0){
          Death(); 
        }
    }

    


}
