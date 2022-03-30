using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Stats
    int level;

    int currentHP;
    int maxHP;

    int currentMana;
    int maxMana;

    int physDamage;
    int magicDamage;
    int block;

    int vigor;
    int mind;
    int strength;
    int intelligence;
    int dexterity;

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
}


