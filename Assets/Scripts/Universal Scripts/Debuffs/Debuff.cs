using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debuff : MonoBehaviour
{
    /*These are Debuffs, that can be put on enemies. They can either have a Tick-Effect that triggers each turn
      and/or a Trigger-Effect that triggers, when the enemy is hit. */
    #region Variables

    public Player Player;
    public Enemy Enemy;
    public Image DebuffSprite;
    public Text DebuffTimer;

    public string Name;
    private int duration;
    private bool isActive = false;

    #endregion
    
    public virtual void ApplyDebuffToEnemy(int turns, Enemy target)
    {
        DebuffSprite.enabled = true;
        DebuffTimer.text = turns.ToString();
    }

    public virtual void ApplyDebuffToPlayer(int turns, Player target)
    {
        DebuffSprite.enabled = true;
        DebuffTimer.text = turns.ToString();
    }

    public virtual void TriggerEffect()
    {
        DebuffSprite.enabled = false;    
    }

    public virtual void TickEffect()
    {

    }

    #region Setter/Getter
    
    public void SetDuration(int amount)
    {
        duration = amount;
    }
    
    public int GetDuration()
    {
        return duration;
    }

    public void SetActive(bool state)
    {
        isActive = state;

        if(!GetActive())
        {
            DebuffSprite.enabled = false;
            DebuffTimer.text = "";
        }
    }

    public bool GetActive()
    {
        return isActive;
    }

    #endregion

    #region Inc/Dec

    public void IncDuration(int amount)
    {
        duration += amount;
    }

    public void DecDuration(int amount)
    {
        duration -= amount;
    }
    
    #endregion
}

