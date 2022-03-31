using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Stats

    private int level;

    private int currentHP;
    private int maxHP;

    private int currentMana;
    private int maxMana;

    private int physDamage;
    private int magicDamage;
    private int block;

    private int vigor;
    private int mind;
    private int strength;
    private int intelligence;
    private int dexterity;

    #endregion  

    #region Texts 

    //display current stat lvl
    public Text vigText; 
    public Text minText;
    public Text dexText;
    public Text strText;
    public Text intText;
    
    #endregion

    #region Set/Get Stats
  
    public void SetLevel(int lvl)
    {
        level = lvl + GetLevel();
    }

    public int GetLevel()
    {
        return level;
    }
    public void SetCurrentHP(int hp)
    {
        currentHP = hp;
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    public void SetMaxHP(int hp)
    {
        maxHP = hp;
    }

    public int GetMaxtHP()
    {
        return maxHP;
    }

    public void SetCurrentMana(int mana)
    {
        currentMana = mana;
    }

    public int GetCurrentMana()
    {
        return currentMana;
    }

    public void SetMaxMana(int mana)
    {
        maxMana = mana;
    }

    public int GetMaxtMana()
    {
        return maxMana;
    }

    public void SetPhysDamage(int dmg)
    {
        physDamage = dmg;
    }

    public int GetPhysDamage()
    {
        return physDamage;
    }

    public void SetMagicDamage(int dmg)
    {
        magicDamage = dmg;
    }

    public int GetMagicDamage()
    {
        return magicDamage;
    }

    public void SetBlock(int amount)
    {
        block = amount;
    }

    public int GetBlock()
    {
        return block;
    }

    public int GetVigor()
    {
        return vigor;
    }

    public void SetVigor(int amount)
    {
        vigor = amount;
    }

    public int GetMind()
    {
        return mind;
    }

    public void SetMind(int amount)
    {
        mind = amount;
    }

    public int GetStrength()
    {
        return strength;
    }

    public void SetStrength(int amount)
    {
        strength = amount;
    }

    public int GetIntelligence()
    {
        return intelligence;
    }

    public void SetIntelligence(int amount)
    {
        intelligence = amount;
    }

    public int GetDexterity() 
    {
        return dexterity;
    }

    public void SetDexterity(int amount)
    {
        dexterity = amount;
    }
    #endregion

    #region Actions

    public void TakeDamage(int dmg)
    {
        int hp = GetCurrentHP() - dmg;

        SetCurrentHP(hp);
    }

    public void Heal(int hp)
    {
        if (GetCurrentHP() + hp <= GetMaxtHP())
        {
            SetCurrentHP(GetCurrentHP() + hp);
        }
        else
        {
            SetCurrentHP(GetMaxtHP());
        }
    }

    public void Die()
    {

    }
    #endregion

    
    public void Update()
    {
        vigText.Text = vigor.ToString();
        minText.Text = mind.ToString();
        dexText.Text = dexterity.ToString();
        strText.Text = strength.ToString();
        intText.Text = intelligence.ToString();
    }
}


