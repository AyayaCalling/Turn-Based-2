using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class manages all occuring event-rooms of the game.
public class Eventroom : MonoBehaviour
{

    public Player Player;
    public PlayerHUD PlayerHUD;

    public SceneHandler SceneHandler;

    public ExitCreation ExitCreation;

    //This is the displayed Event Text, that describes the ongoing event to the player.
    public Text EventText;

    //These are the Options, that will be given to the player.
    public Text ActionOne;
    public Text ActionTwo;
    public Text ActionThree;
    public Text ActionFour;

    //This randomized int decides, what event will be triggered.
    /*List of Possible Events by Event-Code:
    1. Mind, Dex, Strength or Intelligence LvL-Up.
    2. Gain 5 Max HP, Heal to Full, Decrease your current Hp to 1 but gain 100 max HP, Lose 10 max hp but gain 3 Strength.
    3. ...
    4. ...
    5. ...
    6. ...
    */
    private int eventCode;
    private int numberOfPossibleEvents = 2;

    //These are the Methods for the Buttons, that the player can press during an Event.
    public void EventButtonOne()
    {
        switch(eventCode)
        {
            case 1:
                Player.IncMin(1);
                break;
            
            case 2:
                Player.IncMaxHP(5);
                break;

            default: 
                Debug.Log("This Event has not been created yet!");
                break;
        }

        ExitEvent();
    }

    public void EventButtonTwo()
    {
        switch(eventCode)
        {
            case 1:
                Player.IncDex(1);
                break;
            
            case 2:
                Player.SetCurrentHP(Player.GetMaxHP());
                break;

            default: 
                Debug.Log("This Event has not been created yet!");
                break;
        }

        ExitEvent();
    }

    public void EventButtonThree()
    {   
        switch(eventCode)
        {
            case 1:
                Player.IncStr(1);
                break;
            
            case 2:
                Player.DecMaxHP(10);
                Player.IncStr(3);
                break;

            default: 
                Debug.Log("This Event has not been created yet!");
                break;
        }

        ExitEvent();
    }

    public void EventButtonFour()
    {
        switch(eventCode)
        {
            case 1:
                Player.IncInt(1);
                break;
            
            case 2:
                Player.SetCurrentHP(1);
                Player.IncMaxHP(100);
                break;

            default: 
                Debug.Log("This Event has not been created yet!");
                break;
        }

        ExitEvent();
    }

    //This randomizes the Eventcode and changes all important text descriptions.
    public void CreateEvent()
   {
        eventCode = Random.Range(1,(numberOfPossibleEvents + 1));

        switch(eventCode)
        {
            case 1:
                EventText.text = "You will be granted one Level-Up. Choose your desired Stat wisely!";
                ActionOne.text = "Level Mind";
                ActionTwo.text = "Level Strength";
                ActionThree.text = "Level Dexterity";
                ActionFour.text = "Level Intelligence";
                break;

            case 2:
                EventText.text = "Choose one of 4 powers to obtain";
                ActionOne.text = "Gain 5 Max HP";
                ActionTwo.text = "Heal to full HP";
                ActionThree.text = "Lose 10 HP but gain 3 Strength";
                ActionFour.text = "Lose all current HP but 1. In return gain 100 Max HP";
                break;

            default: 
                Debug.Log("This Event has not been created yet!");
                break;

        }
   }

    public void ExitEvent()
    {    
        Debug.Log("You've made your choice. Now Leave this place!");

        PlayerHUD.updateSliders();

        SceneHandler.EventUI.SetActive(false);
        Player.PlayerObj.SetActive(true);
        ExitCreation.CreateFixExit("Fight");
    }
}
