using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelOne ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Car3");
    }

    public void LevelTwo ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mySon1-18");
    }

    public void StartMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void LevelThree()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Jan13AIWork");
    }
}
