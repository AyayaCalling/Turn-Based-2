using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScaler : MonoBehaviour
{
    public Player Player;

    //These variables are used to change the scaling skill values.
    public Skill SkillOne;
    public Skill SkillTwo;
    public Skill SkillThree;

    //These values decide on the skills specific scaling.
    private int knightStrikeBase = 50;
    private float knightStrikeScalingPhys = 0.5f;
    private float knightStrikeScalingMagic = 0f;

    private int knightDefendBase = 5;
    private float knightDefendScaling = 0.75f;


    public void Awake()
    {
        SetBaseValue();
        ScaleStatValue();
    }


    public void SetBaseValue()
    {
        switch(Player.PlayerObj.name)
        {
            case "Knight":
                SkillOne.SetBaseDamage(knightStrikeBase);
                break;
            
            default:
                Debug.Log("There's no such class.");
                break;
        }
    
    }

    public void ScaleStatValue()
    {
        switch(Player.PlayerObj.name)
        {
            case "Knight":
                SkillOne.SetStatDamage(Mathf.RoundToInt(Player.GetPhysDamage() * knightStrikeScalingPhys), Mathf.RoundToInt(Player.GetMagicDamage() * knightStrikeScalingMagic));
                SkillOne.UpdateUI();
                break;
            
            default:
                Debug.Log("There's no such class.");
                break;
        }
    }

    public void ScaleItemDamage()
    {

    }

    #region Getter/Setter

    public void SetKnightStrikePhysScaling(float value)
    {
        knightStrikeScalingPhys = value;
        SkillOne.UpdateUI();
    }

    public void SetKnightStrikeMagicScaling(float value)
    {
        knightStrikeScalingMagic = value;
        SkillOne.UpdateUI();
    }

    public float GetKnightStrikePhysScaling()
    {
        return knightStrikeScalingPhys;
    }

    public float GetKnightStrikeMagicScaling()
    {
        return knightStrikeScalingMagic;
    }

    #endregion
}

