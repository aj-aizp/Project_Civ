using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

/*
Pause Menu script and Game Over screen. Similar logic to Main Menu Script. Add an event Messenger for game over event. 
*/
public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameObject pausePanel; 
   [SerializeField] GameObject gameoverPanel; 
   [SerializeField] GameObject howToPanel; 

// Game Over listener. Listens if Game Over Event has been triggered.
 void OnEnable() {
    Messenger.AddListener(GameEvent.GAME_OVER, gameOver); 
   }

void OnDisable() {
    Messenger.RemoveListener(GameEvent.GAME_OVER, gameOver); 
}

   //Game over screen 
   public void gameOver() {
    gameoverPanel.SetActive(true);
    Time.timeScale = 0; 
   }

  //Button logic 
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
