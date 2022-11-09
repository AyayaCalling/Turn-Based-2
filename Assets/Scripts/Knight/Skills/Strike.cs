using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Class contains the basic variables and methods for Attacking/Striking in the game.
public class Strike : Skill
{
    #region Variables

    // These variables are used to display and calculate the battle phase.
    public TargettingSystem targetter;
    public Battlesystem battle;

    float u21Scaling = 0.5f;
    float u22Scaling = 1f;
    int u23Stacks;

    private bool lastUsed;

    #endregion

//This method will trigger every action binded to the "Strike" skill of "Knight".
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
                //add different Upgrade effects here.

                battle.DealDamageToEnemy(targetter.target, damage);

                Player.DecCurrentMana(GetManaCost());

                observer.ManaValueChange();

                SetLastUsed(true);
            }
        }
        else
        {
            Debug.Log("Please select a valid target!");
        }
    }

    #endregion

    #region Upgrades

    public void ApplyUpgrades()
    {
        if(GetUpgrade21() == true && scaler.GetKnightStrikeMagicScaling != u21Scaling){scaler.SetKnightStrikeMagicScaling(u21Scaling)}
        if(GetUpgrade22() == true && scaler.GetKnightStrikePhysScaling != u22Scaling){scaler.SetKnightStrikePhysScaling(u22Scaling)}
        if(GetUpgrade23() == true)
            {
                damage = damage*(1+u23Stacks*0.2);
                if(GetLastUsed())
                {
                    u23Stacks +=1;
                }       
            }
    } 

    #endregion

    #region Getter/Setter

    public void SetLastUsed(bool state)
    {
        lastUsed = state;

        if(lastUsed == False)
        {
            u23Stacks = 0;
        }
    }

    public bool GetLastUsed()
    {
        return lastUsed;
    }    
}

