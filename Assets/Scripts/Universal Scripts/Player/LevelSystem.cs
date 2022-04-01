using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    #region Variables
    public Player player;

    public PlayerHUD HUD;

    private int levelups;
    private int vigor;
    private int mind;
    private int dexterity;
    private int strength;
    private int intelligence;


    #endregion

    #region Adjustment Buttons

    public void OnVP()
    {
        vigor += 1;
        levelups += 1;
    }

    public void OnVM()
    {
        if (vigor > 0)
        {
            vigor -= 1;
            levelups -= 1;
        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    public void OnMP()
    {
        mind += 1;
        levelups += 1;
    }

    public void OnMM()
    {
        if (mind > 0)
        {
            mind -= 1;
            levelups -= 1;

        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    public void OnDP()
    {
       dexterity += 1;
        levelups += 1;
    }

    public void OnDM()
    {
        if (dexterity < 0)
        {
            dexterity -= 1;
            levelups -= 1;

        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    public void OnSP()
    {
        strength += 1;
        levelups += 1;
    }

    public void OnSM()
    {
        if (strength < 0)
        {
            strength -= 1;
            levelups -= 1;
        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    public void OnIP()
    {
        intelligence += 1;
        levelups += 1;
    }

    public void OnIM()
    {
        if (intelligence < 0)
        {
            intelligence -= 1;
            levelups -= 1;
        }
        else
        {
            Debug.Log("This stat cannot be lowered any Further");
            return;
        }

    }

    #endregion

    // This Method applies changes and resets the temporary variables.
    public void OnApply()
    {   
        DistributeSkills(vigor, mind, dexterity, strength, intelligence);
        vigor = 0;
        mind = 0;
        dexterity = 0;
        strength = 0;
        intelligence = 0;
    }


    // This Method correctly distributes the temporary stats to the overall stats of the character.
    private void DistributeSkills(int vig, int mind, int dex, int str, int intel)
    {     
        player.SetVigor(vig + player.GetVigor());
        player.SetMind(mind + player.GetMind());
        player.SetDexterity(dex + player.GetDexterity());
        player.SetStrength(str + player.GetStrength());
        player.SetIntelligence(intel + player.GetIntelligence());

        player.SetMaxHP(50 + player.GetVigor());
        player.SetMaxMana(3 + player.GetMind());
        player.SetPhysDamage(5 + player.GetStrength());
        player.SetMagicDamage(5 + player.GetIntelligence());
        player.SetCurrentHP(player.GetCurrentHP() + vig);
        player.SetCurrentMana(player.GetCurrentMana() + mind);

        HUD.updateSliders();
    }
}
