using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class Manages all Scenes in the Game. It will load fights, events, close the game and start it.
public class SceneHandler : MonoBehaviour
{
    //This variable holds all Hud information used by this class.
    public HUD HUD;

    //This variable represents the currently selected Character.
    private string character;

    #region Character Selection

    //This method sets the selected Character
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

    //This method returns the currently selected Character.
    public string GetCharacter()
    {
        return character;
    }

    #endregion

    //These methods Load different core scenes of the game, such as: Main Menu and First Fight.
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

    //These methods are used to load the different rooms after using a door.
    #region Load Areas;

    //Loads a standart Fight.
    public void LoadFight()
    {
        HUD.DestroyDoors();
        SceneManager.LoadScene("Fight");
        Debug.Log("Loading next Fight!");
    }

    //Loads an Event
    public void LoadEvent()
    {
        HUD.DestroyDoors();
        SceneManager.LoadScene("Event");
        Debug.Log("Loading next Event!");
    }

    //Loads a Restsite to Heal or enhance a Skill.
    public void LoadRest()
    {
        HUD.DestroyDoors();
        SceneManager.LoadScene("Rest");
        Debug.Log("Loading next Rest!");
    }

    #endregion

    //Quits the Game.....yes that's it.
    public void QuitGame()
    {
        Application.Quit();
    }
}
