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
    public Player Player;

    // This variable stores the values for the HUD.
    public PlayerHUD HUD;

    // These variables handle Pop-Ups and Button presses.

    public GameObject LevelWindow;
    public Button OpenButton;
    public Button CloseButton;

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

    #region TextMessages

    //display current stat lvl.
    public Text vigValueText; 
    public Text minValueText;
    public Text dexValueText;
    public Text strValueText;
    public Text intValueText;

    //display temp stat lvl.
    public Text vigTempText;
    public Text minTempText;
    public Text dexTempText;
    public Text strTempText;
    public Text intTempText;
    
    #endregion

    // FEHLT NOCH LEVEL ÄNDERUNGEN BEI ALLEN AUßER VIGOR
    #region ButtonMethods

    // This Method increases the tempVigor variable.
    public void IncreaseTempVig()
    {
        if (Player.GetLevelToSpentI() > 0) {
            tempVigor += 1;
            tempLevelups += 1;
            Player.DecLevelToSpent(1);

            vigTempText.text = "+" + tempVigor.ToString();
        } else {
            Debug.Log("Cant spend skill point without having a skill point :)");
        }
    }

    // This Method decreases the tempVigor variable (if possible).
    public void DecreaseTempVig()
    {
        if (tempVigor > 0)
        {
            tempVigor -= 1;
            tempLevelups -= 1;
            Player.IncLevelToSpent(1);

            vigTempText.text = "+" + tempVigor.ToString();
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
        if (Player.GetLevelToSpentI() > 0)
        {
            tempMind += 1;
            tempLevelups += 1;
            Player.DecLevelToSpent(1);

            minTempText.text = "+" + tempMind.ToString();
        }
        else 
        {
            Debug.Log("Cant spend skill point without having a skill point :)");
        }
    }

    // This Method decreases the tempMind variable (if possible).
    public void DecreaseTempMin()
    {
        if (tempMind > 0)
        {
            tempMind -= 1;
            tempLevelups -= 1;
            Player.IncLevelToSpent(1);

            minTempText.text = "+" + tempMind.ToString();
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
        if(Player.GetLevelToSpentI() > 0)
        {   
            tempDexterity += 1;
            tempLevelups += 1;
            Player.DecLevelToSpent(1);
            
            dexTempText.text = "+" + tempDexterity.ToString();
        }
    }
    // This Method decreases the tempDexterity variable (if possible).
    public void DecreaseTempDex()
    {
        if (tempDexterity > 0)
        {
            tempDexterity -= 1;
            tempLevelups -= 1;
            Player.IncLevelToSpent(1);

            dexTempText.text = "+" + tempDexterity.ToString();
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
        if(Player.GetLevelToSpentI() > 0)
        {
            tempStrength += 1;
            tempLevelups += 1;
            Player.DecLevelToSpent(1);

            strTempText.text = "+" + tempStrength.ToString();
        }
    }
    // This Method decreases the tempStrength variable (if possible).
    public void DecreaseTempStr()
    {
        if (tempStrength > 0)
        {
            tempStrength -= 1;
            tempLevelups -= 1;
            Player.IncLevelToSpent(1);

            strTempText.text = "+" + tempStrength.ToString();
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
        if(Player.GetLevelToSpentI() > 0)
        {
            tempIntelligence += 1;
            tempLevelups += 1;
            Player.DecLevelToSpent(1);

            intTempText.text = "+" + tempIntelligence.ToString();
        }
    }
    // This Method decreases the tempIntelligence variable (if possible).
    public void DecreaseTempInt()
    {
        if (tempIntelligence > 0)
        {
            tempIntelligence -= 1;
            tempLevelups -= 1;
            Player.IncLevelToSpent(1);

            intTempText.text = "+" + tempIntelligence.ToString();
        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    // These Methods open/close the leveling Menu.
    public void OpenLeveling()
    {
        LevelWindow.SetActive(true);
        OpenButton.interactable = false;
        CloseButton.interactable = true;
    }

    public void CloseLeveling()
    {
        LevelWindow.SetActive(false);
        OpenButton.interactable = true;
        CloseButton.interactable = false;
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

        vigTempText.text = "+0";
        minTempText.text = "+0";
        dexTempText.text = "+0";
        strTempText.text = "+0";
        intTempText.text = "+0";
    }


    // This Method correctly distributes the temporary stats to the overall stats of the character.
    private void DistributeSkills(int vig, int mind, int dex, int str, int intel)
    {     
        Player.IncVig(vig);
        vigValueText.text = Player.GetVigor().ToString();

        Player.IncMin(mind);
        minValueText.text = Player.GetMind().ToString();

        Player.IncDex(dex);
        dexValueText.text = Player.GetDexterity().ToString();

        Player.IncStr(str);
        strValueText.text = Player.GetStrength().ToString();

        Player.IncInt(intel);
        intValueText.text = Player.GetIntelligence().ToString();

        Player.IncMaxHP(vig);
        Player.IncMaxMana(mind);
        Player.IncCurrentHP(vig);
        Player.IncCurrentMana(mind);
        Player.IncPhysDmg(str);
        Player.IncMagiDmg(intel);

        HUD.updateSliders();
    }

    #endregion

}
