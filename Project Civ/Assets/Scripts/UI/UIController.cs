using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIController : MonoBehaviour
{
   [SerializeField] private TMP_Text scoreLabel; 
   [SerializeField] private TMP_Text secondsLabel;
   [SerializeField] private TMP_Text minutesLabel;  
   [SerializeField] private TMP_Text healthLabel;  

   private int score; 
   private float time;
   private int seconds;
   private int minutes;  
   private bool isSpawning; 
   private int health; 

     void OnEnable() {
        Messenger.AddListener(GameEvent.ENEMY_SOL_DEATH, OnEnemySolDeath); 
        Messenger<int>.AddListener(GameEvent.SAND_HEALTH,sandBagUpdate); 
        
   }

   void OnDisable() {
    Messenger.RemoveListener(GameEvent.ENEMY_SOL_DEATH, OnEnemySolDeath); 
    Messenger<int>.RemoveListener(GameEvent.SAND_HEALTH,sandBagUpdate); 
   }

   private void OnEnemySolDeath() {
    score +=10; 
    scoreLabel.text = score.ToString(); 
   }

   private void sandBagUpdate(int health) {

    healthLabel.text = health.ToString(); 
   }



   private void Start() {
    score = 0; 
    time = 0.0f; 
    seconds = 0; 
    minutes = 0; 
    isSpawning = false; 
    scoreLabel.text = score.ToString(); 
    secondsLabel.text = seconds.ToString(); 
    minutesLabel.text = minutes.ToString(); 


   }


private void Update() {
    time += Time.deltaTime; 
    seconds = (int)time % 60 ;
    minutes = (int)time / 60; 

    if(seconds%20 ==0 && isSpawning == false ) {
        isSpawning = true; 
        Messenger.Broadcast(GameEvent.WAVE_SPAWN); 
    }

    if (seconds%20 ==1) {
        isSpawning = false; 
    }

    if(Input.GetKeyUp("1") && score >=100){
        Messenger<int>.Broadcast(GameEvent.SOLDIER_BOUGHT, score);
        score -=100;
    }

     if(Input.GetKeyUp("2") && score >=200) {
        Messenger.Broadcast(GameEvent.MACHINE_GUNNER_BOUGHT);
        score -=200;
    }

    if(Input.GetKeyUp("3") && score >=300) {
        Messenger.Broadcast(GameEvent.ARTY_BOUGHT);
        score -=300;
    }


    
    scoreLabel.text = score.ToString(); 
    secondsLabel.text = seconds.ToString();
    minutesLabel.text = minutes.ToString(); 
}
   }

