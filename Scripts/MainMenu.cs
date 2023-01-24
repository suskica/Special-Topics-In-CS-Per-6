using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelOne ()
    {
        SceneManager.LoadScene("Car3");
    }

    public void LevelTwo ()
    {
        SceneManager.LoadScene("mySon1-18");
    }
}
