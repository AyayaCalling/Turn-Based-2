using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Class contains the LevelSystem for the character.
// You can increase the 5 different stats by spending Levelups.
public class LevelSystem : MonoBehaviour
{
    #region Variables

    // This variable stores the values and actions of the player.
    public Player player;

    // This variable stores the values for the HUD.
    public PlayerHUD HUD;

    // These variables are defined base Stats for the character. 
    private readonly int baseHP = 50;
    private readonly int baseMana = 3;
    private readonly int basePhysical = 5;
    private readonly int baseMagical = 5; 

    // These variables are the temporary version to increase the individual player stats.
    private int tempLevelups;
    private int tempVigor;
    private int tempMind;
    private int tempDexterity;
    private int tempStrength;
    private int tempIntelligence;

    #endregion

    #region ButtonMethods

    // This Method increases the tempVigor variable.
    public void IncreaseTempVig()
    {
        tempVigor += 1;
        tempLevelups += 1;
    }

    // This Method decreases the tempVigor variable (if possible).
    public void DecreaseTempVig()
    {
        if (tempVigor > 0)
        {
            tempVigor -= 1;
            tempLevelups -= 1;
        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    // This Method increases the tempMind variable.
    public void IncreaseTempMin()
    {
        tempMind += 1;
        tempLevelups += 1;
    }

    // This Method decreases the tempMind variable (if possible).
    public void DecreaseTempMin()
    {
        if (tempMind > 0)
        {
            tempMind -= 1;
            tempLevelups -= 1;

        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    // This Method increases the tempDexterity variable.
    public void IncreaseTempDex()
    {
        tempDexterity += 1;
        tempLevelups += 1;
    }

    // This Method decreases the tempDexterity variable (if possible).
    public void DecreaseTempDex()
    {
        if (tempDexterity > 0)
        {
            tempDexterity -= 1;
            tempLevelups -= 1;

        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    // This Method increases the tempStrength variable.
    public void IncreaseTempStr()
    {
        tempStrength += 1;
        tempLevelups += 1;
    }

    // This Method decreases the tempStrength variable (if possible).
    public void DecreaseTempStr()
    {
        if (tempStrength > 0)
        {
            tempStrength -= 1;
            tempLevelups -= 1;
        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    // This Method increases the tempIntelligence variable.
    public void IncreaseTempInt()
    {
        tempIntelligence += 1;
        tempLevelups += 1;
    }

    // This Method decreases the tempIntelligence variable (if possible).
    public void DecreaseTempInt()
    {
        if (tempIntelligence > 0)
        {
            tempIntelligence -= 1;
            tempLevelups -= 1;
        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    #endregion

    #region ApplyChangedStats

    // This Method applies changes and resets the temporary variables.
    public void OnApply()
    {   
        DistributeSkills(tempVigor, tempMind, tempDexterity, tempStrength, tempIntelligence);
        tempVigor = 0;
        tempMind = 0;
        tempDexterity = 0;
        tempStrength = 0;
        tempIntelligence = 0;
    }


    // This Method correctly distributes the temporary stats to the overall stats of the character.
    private void DistributeSkills(int vig, int mind, int dex, int str, int intel)
    {     
        player.SetVigor(vig + player.GetVigor());
        player.SetMind(mind + player.GetMind());
        player.SetDexterity(dex + player.GetDexterity());
        player.SetStrength(str + player.GetStrength());
        player.SetIntelligence(intel + player.GetIntelligence());

        player.SetMaxHP(baseHP + player.GetVigor());
        player.SetMaxMana(baseMana + player.GetMind());
        player.SetPhysDamage(basePhysical+ player.GetStrength());
        player.SetMagicDamage(baseMagical + player.GetIntelligence());
        player.SetCurrentHP(player.GetCurrentHP() + vig);
        player.SetCurrentMana(player.GetCurrentMana() + mind);

        HUD.updateSliders();
    }

    #endregion

}
