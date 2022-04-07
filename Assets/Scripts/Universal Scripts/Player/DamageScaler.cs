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
    private int knightStrikeBase = 15;
    private float knightStrikeScaling = 0.5f;

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
                SkillOne.SetStatDamage(Mathf.RoundToInt(Player.GetPhysDamage() * knightStrikeScaling));
                break;
            
            default:
                Debug.Log("There's no such class.");
                break;
        }
    }

    public void ScaleItemDamage()
    {

    }
}
