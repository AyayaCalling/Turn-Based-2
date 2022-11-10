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
    private bool u21Applied;
    private bool u22Applied;
    private int u23Stacks;

    #endregion

    public void Awake()
    {
        SetUpgradeScaling(21, 0.5f);
        SetUpgradeScaling(22, 1.5f);
    }
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
                ModifyStrike();

                battle.DealDamageToEnemy(targetter.target, GetTotalDamage());

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

    public void ModifyStrike()
    {
        if(GetUpgrade21() == true && u21Applied == false)
        {
            scaler.SetKnightStrikeMagicScaling(GetUpgradeScaling(21));
            scaler.ScaleStatValue();
            u21Applied = true;
        }
        if(GetUpgrade22() == true && u22Applied == false)
        {
            scaler.SetKnightStrikePhysScaling(GetUpgradeScaling(22));
            scaler.ScaleStatValue();
            u22Applied = true;
        }

        float damage = (GetBaseDamage() + GetStatDamage() + GetItemDamage()) * (1-Player.GetWeakness());

        if(GetUpgrade23() == true)
            {
                damage = damage*(1+u23Stacks*0.2f);
                if(GetLastUsed() && u23Stacks <= 3)
                {
                    u23Stacks +=1;
                }       
            }

        //Total damage Set
        SetTotalDamage(Mathf.RoundToInt(damage));
    } 

    #endregion

}

