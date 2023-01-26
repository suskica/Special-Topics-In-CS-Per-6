using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Loads the Level One Scene from the Project Build using the Scene Manager
    public void LevelOne ()
    {
        // Time Scale Unpauses the game, this is the same for all Time.timeScale = 1f methods
        Time.timeScale = 1f;
        SceneManager.LoadScene("Car3");
    }

    // Loads the Level Two Scene from the Project Build using the Scene Manager
    public void LevelTwo ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mySon1-18");
    }

    // Loads the Level Three Scene from the Project Build using the Scene Manager
    public void StartMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    // Loads the Main Menu Scene from the Project Build using the Scene Manager
    public void LevelThree()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Jan13AIWork");
    }
}
