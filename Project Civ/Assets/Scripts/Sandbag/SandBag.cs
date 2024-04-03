using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Handles sandbag health. Sends out health information to UI. Also broadcasts when Game over event is triggered. 
*/
public class SandBag : MonoBehaviour
{
     public int health;
  
    //update total health 
    public void Damage (int damage) {
        this.health -= damage;
        Debug.Log(health); 
        Messenger<int>.Broadcast(GameEvent.SAND_HEALTH, health);  
    }

    //When Sandbag healh reaches 0 or less, the game is over 
    private void Update() {
        if(health <= 0 ) {
            Messenger.Broadcast(GameEvent.GAME_OVER); 
        }
    }
}
