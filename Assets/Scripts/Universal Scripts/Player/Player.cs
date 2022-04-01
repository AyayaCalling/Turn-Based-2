using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables

    // This variable displays the current level of the player.
    private int level;

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

    #endregion  

    // Nicht alle Setter notwendig (public), bei manchhen sind increase/decrease sinnvoller
    #region GetterAndSetter
  
    // Getter-Method for the Variable level.
    public int GetLevel()
    {
        return level;
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
    #endregion


    // Es fehlen noch inc/dec befehle ab physDmg
    #region Inc/Dec-Methods

    // This method increases level by the value lvl.
    public void IncLevel(int lvl)
    {
        level = lvl + GetLevel();
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

    #endregion

    #region Actions

    // This Method describes the process of taking damage and executes it.
    public void TakeDamage(int dmg)
    {
        DecCurrentHP(dmg);
    }

    // This Method describes the process of healing and executes it.
    public void Heal(int hp)
    {
        IncCurrentHP(hp);
    }

    // This Method describes the process of dying and executes it.
    // NOT IMPLEMENTED
    public void Die()
    {

    }

    #endregion


    // kann zu Levelsystem, an richtige stelle! und player. davor

    #region TextMessages

    //display current stat lvl
    public Text vigText; 
    public Text minText;
    public Text dexText;
    public Text strText;
    public Text intText;
    
    #endregion

    public void Update()
    {
        vigText.text = vigor.ToString();
        minText.text = mind.ToString();
        dexText.text = dexterity.ToString();
        strText.text = strength.ToString();
        intText.text = intelligence.ToString();
    }
}


