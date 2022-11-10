using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    // This variable describes the current instance of the player.
    public Player Player;

    //This variable describes the Button that needs to be pressed, to trigger the Skill-Activation.
    public Button SkillButton;

    //This variable stores information for the Skills mana cost.
    private int manaCost = 1;

    //This varibale constantly checks for availability of the Skill.
    public ManaObserver observer;

    //These variables scale the Skilldamage the player will deal.
    public DamageScaler scaler;
    private int baseDamage;
    private int statDamage;
    private int itemDamage;
    private int totalDamage;

    private bool lastUsed;

    //These bools handle Skill-Upgrade-Tracking
    private bool u2P1 = false;
    private bool u2P2 = true;
    private bool u2P3 = false;
    private bool u3P1 = false;
    private bool u3P2 = false;
    private bool u3P3 = false;

    //These variables determine scalings of Skill Upgrades.
    private float u21Scaling;
    private float u22Scaling;
    private float u23Scaling;
    private float u31Scaling;
    private float u32Scaling;
    private float u33Scaling;

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

    public void SetStatDamage(int physDmg, int magicDmg)
    {
        statDamage = physDmg + magicDmg;
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
    
    public bool GetUpgrade21()
    {    
        return u2P1;
    }

    public bool GetUpgrade22()
    {    
        return u2P2;
    }

    public bool GetUpgrade23()
    {    
        return u2P3;
    }

    public bool GetUpgrade31()
    {    
        return u3P1;
    }

    public bool GetUpgrade32()
    {    
        return u3P2;
    }

    public bool GetUpgrade33()
    {    
        return u3P3;
    }

    public void SetUpgrade11(bool u21, bool u22, bool u23, bool u31, bool u32, bool u33)
    {    
        u2P1 = u21;
        u2P2 = u22;
        u2P3 = u23;
        u3P1 = u31;
        u3P2 = u32;
        u3P3 = u33;
    }

    public float GetUpgradeScaling(int iD)
    {
        switch(iD)
        {
            case 21:
                return u21Scaling;
                

            case 22:
                return u22Scaling;                
            case 23:
                return u23Scaling;                
            case 31:
                return u31Scaling;
            case 32:
                return u32Scaling;
            case 33:
                return u33Scaling;
            default:
                Debug.Log("There's no such Upgrade!");
                return 0;

        }
    }
    
    public void SetUpgradeScaling(int iD, float scaleValue)
    {
        switch(iD)
        {
            case 21:
                u21Scaling = scaleValue;
                break;

            case 22:
                u22Scaling = scaleValue;
                break;
            case 23:
                u23Scaling = scaleValue;
                break;
            case 31:
                u31Scaling = scaleValue;
                break;
            case 32:
                u32Scaling = scaleValue;
                break;
            case 33:
                u33Scaling = scaleValue;
                break;
            default:
                Debug.Log("There's no such Upgrade!");
                break;   
        }
    }

    //Getter-Method for the Skills mana cost
    public int GetManaCost()
    {
        return manaCost;
    }

    //Setter-Method for the Skills mana cost
    public void SetManaCost(int cost)
    {
        manaCost = cost;
    }

    public void SetLastUsed(bool state)
    {
        lastUsed = state;

    }

    public bool GetLastUsed()
    {
        return lastUsed;
    }   

    public void SetTotalDamage(int value)
    {
        totalDamage = value;
    }

    public int GetTotalDamage()
    {
        return totalDamage;
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

}
