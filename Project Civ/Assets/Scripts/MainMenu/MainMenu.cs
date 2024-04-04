using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/*
Responsible for Main Menu scene management. Also includes logic for the different buttons.
*/
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    //Remember scenes stored in array. Index 0 = Main Menu, Index 1 = Game
    public void Game()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    //Button logics
    public void Manual()
    {
        panel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        panel.SetActive(false);
    }
}
