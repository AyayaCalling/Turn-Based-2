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

    //Knight's Strike only variables:
    private bool u21Applied;
    private bool u22Applied;
    private int u23Stacks;
    private int maxStacks = 3;
    private float stackRatio = 0.2f;
    private int secondHitChance = 40;
    private int thirdHitChance = 80;
    private float secondHitRatio = 0.2f;
    private float thirdHitRatio = 0.1f;

    private int manaReaveDuration = 3;

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
                if(GetLastUsed() == false)
                {
                    u23Stacks = 0;
                    SetLastUsed(true);
                }

                ModifyStrike();

                battle.DealDamageToEnemy(targetter.target, GetTotalDamage());

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

    #region Upgrades

    public void ModifyStrike()
    {
        if(GetUpgrade21() && u21Applied == false)
        {
            scaler.SetKnightStrikeMagicScaling(GetUpgradeScaling(21));
            scaler.ScaleStatValue();
            u21Applied = true;
        }
        if(GetUpgrade22() && u22Applied == false)
        {
            scaler.SetKnightStrikePhysScaling(GetUpgradeScaling(22));
            scaler.ScaleStatValue();
            u22Applied = true;
        }

        float strikeDamage = (GetBaseDamage() + GetStatDamage() + GetItemDamage()) * (1-Player.GetWeakness());

        if(GetUpgrade23())
        {
            float damage23 = strikeDamage*(1+u23Stacks*stackRatio);
            if(GetLastUsed() && u23Stacks < maxStacks)
            {
                u23Stacks +=1;
            }
            SetTotalDamage(Mathf.RoundToInt(damage23));       
        }

        if(GetUpgrade31())
        {
            ManaReave manaReave = new ManaReave(targetter.target, manaReaveDuration);
            Debug.Log(manaReave.Target.ManaReaveSpirte.enabled);
            battle.DebuffEnemy(manaReave, targetter.target, manaReaveDuration);
        }

        if(GetUpgrade33())
        {
            float damage33;
            int rNG = Random.Range(0, 100);
            if(GetUpgrade23())
            {
                u23Stacks -= 1;
                damage33 = strikeDamage*(1+u23Stacks*stackRatio);
            }else
            {
                damage33 = strikeDamage*(1+u23Stacks*stackRatio);
            }
            
            if(GetLastUsed() && u23Stacks < maxStacks && GetUpgrade23())
                {
                    u23Stacks +=1;
                }

            if(rNG >= secondHitChance)
            {
                damage33 += secondHitRatio*strikeDamage*(1+u23Stacks*stackRatio);
                if(GetLastUsed() && u23Stacks < maxStacks && GetUpgrade23())
                    {
                        u23Stacks +=1;
                    }
            }

            if(rNG >= thirdHitChance)
            {
                damage33 += thirdHitRatio*strikeDamage*(1+u23Stacks*stackRatio);
                if(GetLastUsed() && u23Stacks < maxStacks && GetUpgrade23())
                    {
                        u23Stacks +=1;
                    }
            }
            
            SetTotalDamage(Mathf.RoundToInt(damage33));
        }

        if(!GetUpgrade21() && !GetUpgrade22() && !GetUpgrade23())
        {
            SetTotalDamage(Mathf.RoundToInt(strikeDamage));
        }

    } 

    #endregion

}

