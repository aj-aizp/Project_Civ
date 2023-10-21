using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIController : MonoBehaviour
{
   [SerializeField] private TMP_Text scoreLabel; 
   [SerializeField] private TMP_Text secondsLabel;
   [SerializeField] private TMP_Text minutesLabel;  
   private int score; 
   private float time;
   private int seconds;
   private int minutes;  
   private bool isSpawning; 

     void OnEnable() {
        Messenger.AddListener(GameEvent.ENEMY_SOL_DEATH, OnEnemySolDeath); 
   }

   void OnDisable() {
    Messenger.RemoveListener(GameEvent.ENEMY_SOL_DEATH, OnEnemySolDeath); 
   }

   private void OnEnemySolDeath() {
    score +=10; 
    scoreLabel.text = score.ToString(); 
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

    if(seconds%30 ==0 && isSpawning == false ) {
        isSpawning = true; 
        Messenger.Broadcast(GameEvent.WAVE_SPAWN); 
    }

    if (seconds%30 ==1) {
        isSpawning = false; 
    }

    if(Input.GetKeyUp("q") && score >=100){
        Messenger<int>.Broadcast(GameEvent.SOLDIER_BOUGHT, score);
        score -=100;
    }

    if(Input.GetKeyUp("w") && score >=1000) {
        Messenger.Broadcast(GameEvent.ARTY_BOUGHT);
        score -=1000;
    }
    
    scoreLabel.text = score.ToString(); 
    secondsLabel.text = seconds.ToString();
    minutesLabel.text = minutes.ToString(); 
}
   }

