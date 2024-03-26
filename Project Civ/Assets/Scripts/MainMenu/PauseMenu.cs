using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameObject pausePanel; 
   [SerializeField] GameObject gameoverPanel; 
   [SerializeField] GameObject howToPanel; 


 void OnEnable() {
    Messenger.AddListener(GameEvent.GAME_OVER, gameOver); 
   }

void OnDisable() {
    Messenger.RemoveListener(GameEvent.GAME_OVER, gameOver); 
}

   public void gameOver() {
    gameoverPanel.SetActive(true);
    Time.timeScale = 0; 
   }



   public void Pause() {
    pausePanel.SetActive(true); 
    Time.timeScale = 0; 
   }

   public void HowTo() {
   howToPanel.SetActive(true); 
   }

   public void Back() {
    howToPanel.SetActive(false); 
   }


   public void Home() {
    SceneManager.LoadScene(0); 
    Time.timeScale = 1; 
   }

   public void Resume() {
    pausePanel.SetActive(false); 
    Time.timeScale = 1; 
   }

   public void Quit(){
    Application.Quit(); 

   }
}
