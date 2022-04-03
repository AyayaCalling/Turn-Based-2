using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadMainMenu()
    {
       SceneManager.LoadScene("Main Menu");
    }

    public void StartGame()
    {
       SceneManager.LoadScene("Intro Fight");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
