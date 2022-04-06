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

    //These variables scale the Skilldamage the player will deal.
    private int baseDamage;
    private int statDamage;
    private int itemDamage;

    //These methods set and get different values of "Strike".
    #region Setter/Getter

    public void SetBaseDamage(int dmg)
    {
        baseDamage = dmg;
    }

    public int GetBaseDamage()
    {
        return baseDamage;
    }

    public void SetStatDamage(int dmg)
    {
        statDamage = dmg;
    }

    public int GetStatDamage()
    {
        return statDamage;
    }

    public void SetItemDamage(int dmg)
    {
        itemDamage = dmg;
    }

    public int GetItemDamage()
    {
        return itemDamage;
    }
    #endregion

    //These methods increase and decrease different values of "Strike"
    #region  Inc/Dec

    public void IncBaseDamage(int dmg)
    {
        baseDamage += dmg;
    }

    public void DecBaseDamage(int dmg)
    {
        baseDamage -= dmg;
    }

    public void IncStatDamage(int dmg)
    {
        statDamage += dmg;
    }

    public void DecStatDamage(int dmg)
    {
        statDamage -= dmg;
    }

    public void IncItemDamage(int dmg)
    {
        itemDamage += dmg;
    }   

    public void DecItemDamage(int dmg)
    {
        itemDamage -= dmg;
    }
    #endregion

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
