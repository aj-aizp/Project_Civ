using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour
{
     public int health;
  

 
    public void Damage (int damage) {
        this.health -= damage;
        Debug.Log(health); 
        Messenger<int>.Broadcast(GameEvent.SAND_HEALTH, health);  
    }


   
}
