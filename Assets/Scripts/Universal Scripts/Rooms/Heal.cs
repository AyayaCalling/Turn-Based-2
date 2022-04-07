using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class heals the player at restsites
public class Heal : MonoBehaviour
{
    //The player (you know how this works).
    public Player Player;

    //The button that needs to be pressed to heal.
    public Button HealButton;

    //The button that needs to be pressed to enhance a skill.
    public Button SkillUpButton;

    //The button that lets you leave the restsite
    public Button LeaveButton;

    //The ratio the Player is healed for.
    private float healAmount = 0.3f;

    //This method executes the healing proccess.
    public void OnHealButton()
    {
        Player.IncCurrentHP(Mathf.RoundToInt(Player.GetMaxHP() * healAmount));
        Debug.Log("Player got healed for: " + Mathf.RoundToInt(Player.GetMaxHP() * healAmount));

        HealButton.interactable = false;

    }
}
