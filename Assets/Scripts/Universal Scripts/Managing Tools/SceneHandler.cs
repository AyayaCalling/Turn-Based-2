using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class Manages all Scenes in the Game. It will load fights, events, close the game and start it.
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
