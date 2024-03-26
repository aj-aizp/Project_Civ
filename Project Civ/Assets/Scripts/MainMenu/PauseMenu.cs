using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameObject pausePanel; 
   [SerializeField] GameObject howToPanel; 


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
