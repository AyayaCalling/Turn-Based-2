using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    #region Variables
    public Player player;

    private int levelups;
    private int vigor;
    private int mind;
    private int dexterity;
    private int strength;
    private int intelligence;


    #endregion

    #region Adjustment Buttons

    void OnVP()
    {
        vigor += 1;
        levelups += 1;
    }

    void OnVM()
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

    void OnMP()
    {
        mind += 1;
        levelups += 1;
    }

    void OnMM()
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

    void OnDP()
    {
       dexterity += 1;
        levelups += 1;
    }

    void OnDM()
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

    void OnSP()
    {
        strength += 1;
        levelups += 1;
    }

    void OnSM()
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

    void OnIP()
    {
        intelligence += 1;
        levelups += 1;
    }

    void OnIM()
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

    public void OnApply()
    {
        
        DistributeSkills(vigor, mind, dexterity, strength, intelligence);
        vigor = 0;
        mind = 0;
        dexterity = 0;
        strength = 0;
        intelligence = 0;
    }


    void DistributeSkills(int vig, int mind, int dex, int str, int intel)
    {
        player.SetVigor(vig + player.GetVigor());
        player.SetMind(mind + player.GetMind());
        player.SetDexterity(dex + player.GetDexterity());
        player.SetStrength(str + player.GetStrength());
        player.SetIntelligence(intel + player.GetIntelligence());
    }
}
