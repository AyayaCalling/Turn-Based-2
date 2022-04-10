using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class Manages all Scenes in the Game. It will load fights, events, close the game and start it.
public class SceneHandler : MonoBehaviour
{
    //as always
    public Player Player;

    public CharacterSelection CharacterSelection;

    //This variable holds all Hud information used by this class.
    public HUD HUD;

    //This variable represents the currently selected Character.
    private string character;

    //This variable stores all Battlesystem info.
    public Battlesystem Battle;

    //This variable represents the Restsite UI;
    public GameObject RestUI;

    //This variable represents the Event UI;
    public GameObject EventUI;
    public Eventroom EventManager;

    //This variable is the games Fight-Manager.
    public FightCreation FightCreation;

    //This variable tracks how far the player has gotten, to ensure propper timing of Boss-Fights and other scripted encounters.
    private int stage = 1;

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

        CharacterSelection.SelectedCharacter(name);
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
        Destroy(Player.PlayerObj);
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
        Destroy(Player.PlayerObj);
        switch(usedCharacter)
        {
            case "Knight":
                HUD.DestroyHUD();
                SceneManager.LoadScene("Start Knight");
            break;
        }
    }

    //This method increases the stage counter by "amount".
    public void IncStage(int amount)
    {
        stage += amount;
    }

    //These methods set/get the stage counter to "value".
    public void SetStage(int value)
    {
        stage = value;
    }

    public int GetStage()
    {
        return stage;
    }
    //These methods are used to load the different rooms after using a door.
    #region Load Areas;

    //Loads a standard Fight. Currently buggy. New Fight does not allow any actions taken by the Player.
    public void LoadFight()
    {
        SceneManager.LoadScene("Fight");
        Debug.Log("Loading next Fight!");
        FightCreation.CreateFight();
        Battle.ChangeStateToPlayerTurn();
        Battle.UpdateEnemies();
        Debug.Log("Battle State is now changed to Player's turn. " + Battle.Player.GetActive());
        HUD.DestroyDoors();  
        IncStage(1);
    }

    //Loads an Event
    public void LoadEvent()
    {
        HUD.DestroyDoors();
        SceneManager.LoadScene("Event");
        Player.PlayerObj.SetActive(false);
        EventUI.SetActive(true);
        EventManager.CreateEvent();
        Debug.Log("Loading next Event!");
        IncStage(1);
    }

    //Loads a Restsite to Heal or enhance a Skill.
    public void LoadRest()
    {
        SceneManager.LoadScene("Rest");
        Debug.Log("Loading next Rest!");
        HUD.DestroyDoors();
        RestUI.SetActive(true);
        IncStage(1);
    }

    public void LoadBossFight()
    {
        SceneManager.LoadScene("Boss Fight");
        HUD.DestroyDoors();
        FightCreation.CreateBossFight();
        Battle.ChangeStateToPlayerTurn();
        SetStage(0);
    }

    #endregion

    //Quits the Game.....yes that's it.
    public void QuitGame()
    {
        Application.Quit();
    }
}
