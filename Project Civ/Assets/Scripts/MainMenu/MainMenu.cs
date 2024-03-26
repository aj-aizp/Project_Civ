using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject panel; 

    public void Game() {
        SceneManager.LoadScene(1); 
         Time.timeScale = 1; 
    }

    public void Manual() {
        panel.SetActive(true); 
    } 


    public void Quit() {
        Application.Quit(); 
    }

    public void Back(){
        panel.SetActive(false); 
    }

}
