using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Class contains the basic variables and methods for Attacking/ Striking in the game.
public class Strike : Skill
{
    #region Variables

    // These variables are used to display and calculate the battle phase.
    public TargettingSystem targetter;
    public Battlesystem battle;

    //These variables store the damage values for different damage sources.
    private int baseDamage = 10;
    private int statDamage;
    private int itemDamage;

    #endregion

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

    //This method will trigger every action binded to the "Strike" skill of "Knight.
    #region UseStrikeMethod

    /* This Method simulates a Strike.
    /  The player deals damage to the chosen enemy. (if he has enough mana) */
    public void UsingStrike()
    {
        // Checks, if a chosen target is valid.
        if(targetter.target != null)
        {
            if(Player.GetCurrentMana() > 0 && Player.GetActive())
            {
                int damage = Mathf.RoundToInt((GetBaseDamage() + GetStatDamage() + GetItemDamage()) * (1-Player.GetWeakness()));


                battle.DealDamageToEnemy(targetter.target, damage);

                Player.DecCurrentMana(GetManaCost());

                observer.ManaValueChange();
            }
        }
        else
        {
            Debug.Log("Please select a valid target!");
        }
    }

    #endregion

}

