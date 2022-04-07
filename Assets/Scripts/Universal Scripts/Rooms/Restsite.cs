using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is used to manage all actions that can be taken in a "Restsite" Room.
public class Restsite : MonoBehaviour
{
    //The player (you know how this works).
    public Player Player;

    //The button that needs to be pressed to heal.
    public Button HealButton;

    //The button that needs to be pressed to enhance a skill.
    public Button SkillUpButton;

    //The games scene manager.
    public SceneHandler SceneHandler;

    //The class, creating various exits.
    public ExitCreation ExitCreation;

    //The ratio the Player is healed for.
    private float healAmount = 0.3f;

    //This method executes the healing proccess.
    public void OnHealButton()
    {
        Player.IncCurrentHP(Mathf.RoundToInt(Player.GetMaxHP() * healAmount));
        Debug.Log("Player got healed for: " + Mathf.RoundToInt(Player.GetMaxHP() * healAmount));

        SceneHandler.RestUI.SetActive(false);

        ExitCreation.CreateFixExit("Fight");
    }

    //This method opens an overview of all possible Upgrades for your skills. (The upgrading is done in a seperate class).
    public void OnSkillUpButton()
    {
        Debug.Log("Coming Soon.");
    }
}
