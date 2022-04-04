using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class Manages all Scenes in the Game. It will load fights, events, close the game and start it.
public class SceneHandler : MonoBehaviour
{
    public HUD HUD;

    private string character;

    #region Character Selection

    public void SelectCharacter(string name)
    {
        if(character != name)
        {
            character = name;
        }
        else
        {
            character = null;
        }     
    }

    public string GetCharacter()
    {
        return character;
    }

    #endregion

    public void LoadMainMenu()
    {
        HUD.DestroyHUD();
        SceneManager.LoadScene("Main Menu");
    }

    public void StartGame()
    {
        switch(character)
        {
            case "Knight":
                SceneManager.LoadScene("Start Knight");
            break;
        }
    }

    public void Restart(string usedCharacter)
    {
        switch(usedCharacter)
        {
            case "Knight":
                HUD.DestroyHUD();
                SceneManager.LoadScene("Start Knight");
            break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
