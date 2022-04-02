using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    // This variable describes the current instance of the player.
    public Player Player;

    //This variable describes the Button that needs to be pressed, to trigger the Skill-Activation.
    public Button SkillButton;

    //This variable stores information for the Skills mana cost.
    private int manaCost = 1;

    //This varibale constantly checks for availability of the Skill.
    public ManaObserver observer;

    //Getter-Method for the Skills mana cost
    public int GetManaCost()
    {
        return manaCost;
    }

    //Setter-Method for the Skills mana cost
    public void SetManaCost(int cost)
    {
        manaCost = cost;
    }
}
