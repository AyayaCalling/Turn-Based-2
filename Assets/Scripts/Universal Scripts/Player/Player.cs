using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables

    // This variable describes, if the player is allowed to do smth.
    private bool active = true;

    // This variable displays the current level and the levels to spent of the player.
    private int level = 0;
    private float levelToSpent = 0;

    // These variables display the current and maximum HP the player has.
    private int currentHP;
    private int maxHP;

    // These variables display the current and maximum Mana the player has.
    private int currentMana;
    private int maxMana;

    // These variables display the Damage and Block stats of the palyer.
    private int physDamage;
    private int magicDamage;
    private int block;

    // These variables are the indivdual player stats.
    private int vigor;
    private int mind;
    private int strength;
    private int intelligence;
    private int dexterity;

    //These variables are the individual player debuffs.

    //Reduces damage dealt. 0.3 = 30% less damage.
    private float weakness = 0;

    //Increases damage taken. 1.3 = 130% more damage.
    private float vulnerable = 1;

    private int poison;

    //These variables are the duration for every debuff.
    private int weakTurns;
    private int vulnerableTurns;
    private int poisonTurns;

    #endregion  

    #region GetterAndSetter
  
    // Getter-Method for the Variable active.
    public bool GetActive()
    {
        return active;
    }

    //Setter-Method for the Variable active.
    public void SetActive(bool state)
    {
        active = state;
    }

    // Getter-Method for the Variable level.
    public int GetLevel()
    {
        return level;
    }

    // Getter-Method for the Variable levelToSpent in float.
    public float GetLevelToSpentF()
    {
        return levelToSpent;
    }

    // Getter-Method for the Variable levelToSpent in int.
    public int GetLevelToSpentI()
    {
        return (int)levelToSpent;
    }

    // Setter-Method for the Variable currentHP. (only used in the initialization publicly)
    public void SetCurrentHP(int hp)
    {
        currentHP = hp;
    }

    // Getter-Method for the Variable currentHP.
    public int GetCurrentHP()
    {
        return currentHP;
    }

    // Setter-Method for the Variable maxHP. (only used in the initialization publicly)
    public void SetMaxHP(int hp)
    {
        maxHP = hp;
    }

    // Getter-Method for the Variable maxHP.
    public int GetMaxHP()
    {
        return maxHP;
    }

    // Setter-Method for the variable currentMana. (only used in the initialization publicly)
    public void SetCurrentMana(int mana)
    {
        currentMana = mana;
    }

    // Getter-Method for the Variable currentMana.
    public int GetCurrentMana()
    {
        return currentMana;
    }

    // Setter-Method for the Variable maxMana. (only used in the initialization publicly)
    public void SetMaxMana(int mana)
    {
        maxMana = mana;
    }

    // Getter-Method for the Variable maxMana.
    public int GetMaxMana()
    {
        return maxMana;
    }

    // Setter-Method for the variable physDamage. (only used in the initialization publicly)
    public void SetPhysDamage(int dmg)
    {
        physDamage = dmg;
    }

    // Getter-Method for the Variable physDamage.
    public int GetPhysDamage()
    {
        return physDamage;
    }

    // Setter-Method for the variable magicDamage. (only used in the initialization publicly)
    public void SetMagicDamage(int dmg)
    {
        magicDamage = dmg;
    }

    // Getter-Method for the Variable magicDamage.
    public int GetMagicDamage()
    {
        return magicDamage;
    }

    // Setter-Method for the variable block. (only used in the initialization publicly)
    public void SetBlock(int amount)
    {
        block = amount;
    }

    // Getter-Method for the Variable block.
    public int GetBlock()
    {
        return block;
    }

    // Getter-Method for the Variable vigor.
    public int GetVigor()
    {
        return vigor;
    }

    // Setter-Method for the variable vigor. (only used in the initialization publicly)
    public void SetVigor(int amount)
    {
        vigor = amount;
    }

    // Getter-Method for the Variable mind.
    public int GetMind()
    {
        return mind;
    }

    // Setter-Method for the variable mind. (only used in the initialization publicly)
    public void SetMind(int amount)
    {
        mind = amount;
    }

    // Getter-Method for the Variable strength.
    public int GetStrength()
    {
        return strength;
    }

    // Setter-Method for the variable strength. (only used in the initialization publicly)
    public void SetStrength(int amount)
    {
        strength = amount;
    }

    // Getter-Method for the Variable intelligence.
    public int GetIntelligence()
    {
        return intelligence;
    }

    // Setter-Method for the variable intelligence. (only used in the initialization publicly)
    public void SetIntelligence(int amount)
    {
        intelligence = amount;
    }

    // Getter-Method for the Variable dexterity.
    public int GetDexterity() 
    {
        return dexterity;
    }

    // Setter-Method for the variable dexterity. (only used in the initialization publicly)
    public void SetDexterity(int amount)
    {
        dexterity = amount;
    }

    public float GetWeakness()
    {
        return weakness;
    }

    public void SetWeakness(float value)
    {
        weakness = value;
    }

    public int GetWeakTurns()
    {
        return weakTurns;
    }

    public void SetWeakTurns(int turns)
    {
        weakTurns = turns;
    }

    public float GetVulnerable()
    {
        return vulnerable;
    }

    public void SetVulnerable(float value)
    {
        vulnerable = value;
    }

    public int GetVulnerableTurns()
    {
        return vulnerableTurns;
    }

    public void SetVulnerableTurns(int turns)
    {
        vulnerableTurns = turns;
    }
    #endregion

    #region Inc/Dec-Methods


    // This method increases level by the value lvl.
    public void IncLevel(int lvl)
    {
        level = lvl + GetLevel();
    }

    // This method increases levelToSpent by the value lvlAdd.
    public void IncLevelToSpent(float lvlAdd)
    {
        levelToSpent = lvlAdd + GetLevelToSpentF();
    }

    // This method decreases levelToSpent by the value lvlSub.
    public void DecLevelToSpent(int lvlSub)
    {
        levelToSpent = GetLevelToSpentF() - lvlSub;
    } 

    // This method inreases the currentHP by the value addedHP, not above maxHP.
    public void IncCurrentHP(int addedHP)
    {
        int hp = GetCurrentHP() + addedHP;
        if (hp <= GetMaxHP())
        {
            SetCurrentHP(hp);
        }
        else
        {
            SetCurrentHP(GetMaxHP());
        }
        
    }

    // This method decreases the currentHP by the value minusHP, not below 0.
    public void DecCurrentHP(int minusHP)
    {
        int hp = GetCurrentHP() - minusHP;
        if (hp <= 0)
        {
            SetCurrentHP(0);
        } else 
        {
            SetCurrentHP(hp);
        }

    }

    // This method increases the maxHP by the value of addedHP.
    public void IncMaxHP(int addedHP)
    {
        int hp = GetMaxHP() + addedHP;
        SetMaxHP(hp);
    }

    // This method decreases the maxHP by the value of minusHP and changes the currentHP, if they are higher than the new maxHP.
    public void DecMaxHP(int minusHP)
    {
        int hp = GetMaxHP() - minusHP;
        if (hp <= GetCurrentHP())
        {
            SetCurrentHP(hp);
        }
        SetMaxHP(hp);
    }

    // This method inreases the currentMana by the value addedMana, not above maxMana.
    public void IncCurrentMana(int addedMana)
    {
        int mana = GetCurrentMana() + addedMana;
        if (mana <= GetMaxMana())
        {
            SetCurrentMana(mana);
        }
        else
        {
            SetCurrentMana(GetMaxMana());
        }
    }

    // This method decreases the currentMana by the value minusMana, not below 0.
    public void DecCurrentMana(int minusMana)
    {
        int mana = GetCurrentMana() - minusMana;
        if (mana <= 0)
        {
            SetCurrentMana(0);
        } else 
        {
            SetCurrentMana(mana);
        }

    }

     // This method increases the maxMana by the value of addedMana(.
    public void IncMaxMana(int addedMana)
    {
        int mana = GetMaxMana() + addedMana;
        SetMaxMana(mana);
    }

    // This method decreases the maxMana by the value of minusMana and changes the currentMana, if they are higher than the new maxMana.
    public void DecMaxMana(int minusMana)
    {
        int mana = GetMaxMana() - minusMana;
        if (mana <= GetCurrentMana())
        {
            SetCurrentMana(mana);
        }
        SetMaxMana(mana);
    }

    public void DecWeakTurns(int turns)
    {
        if(weakTurns > 0)
        {
            weakTurns -= turns;
        }      
    }

    public void IncWeakturns(int turns)
    {
        weakTurns += turns;
    }

    public void DecVulnerableTurns(int turns)
    {
        if(vulnerableTurns > 0)
        {
            vulnerableTurns -= turns;
        }
    }

    public void IncVulnerableTurns(int turns)
    {
        vulnerableTurns += turns;
    }

    // This (help-)Method adds increase to value. (true = add, false = sub)
    private int ChangeStats(int value, int increase, bool add) {
        if (add)
        {
            value += increase;
        } else
        {
            value -= increase;
        }
        return value;
    }

    // These Methods increase each value.
    public void IncPhysDmg(int addedPhys){ physDamage = ChangeStats(physDamage, addedPhys, true);}
    public void IncMagiDmg(int addedMagi){ magicDamage = ChangeStats(magicDamage, addedMagi, true);}
    public void IncBlock(int addedBlock){ block = ChangeStats(block, addedBlock, true);}
    public void IncVig(int addedVig){ vigor = ChangeStats(vigor, addedVig, true);}
    public void IncMin(int addedMind){ mind = ChangeStats(mind, addedMind, true);}
    public void IncDex(int addedDex){ dexterity = ChangeStats(dexterity, addedDex, true);}
    public void IncStr(int addedStr){ strength = ChangeStats(strength, addedStr, true);}
    public void IncInt(int addedInt){ intelligence = ChangeStats(intelligence, addedInt, true);}

    // These Methods decrease each value.
    public void DecPhysDmg(int minusPhys){ physDamage = ChangeStats(physDamage, minusPhys, false);}
    public void DecMagiDmg(int minusMagi){ magicDamage = ChangeStats(magicDamage, minusMagi, false);}
    public void DecBlock(int minusBlock){ block = ChangeStats(block, minusBlock, false);}
    public void DecVig(int minusVig){ vigor = ChangeStats(vigor, minusVig, false);}
    public void DecMin(int minusMind){ mind = ChangeStats(mind, minusMind, false);}
    public void DecDex(int minusDex){ dexterity = ChangeStats(dexterity, minusDex, false);}
    public void DecStr(int minusStr){ strength = ChangeStats(strength, minusStr, false);}
    public void DecInt(int minusInt){ intelligence = ChangeStats(intelligence, minusInt, false);}

    #endregion

    #region Actions

    // This Method describes the process of dying and executes it.
    // NOT IMPLEMENTED
    public void Die()
    {

    }

    #endregion

}


