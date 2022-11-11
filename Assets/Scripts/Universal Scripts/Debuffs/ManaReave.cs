using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaReave : Debuff
{
    /*The Tick of Mana Reave deals a mind-scaling DoT on the enemy. When triggered this effect
      deals bonus magic damage and restores Mana to the player.*/

    private int baseTriggerDamage = 10;
    private int baseTickDamage = 1;
    private int manaRefund = 5;

    private float mindScaling = 0.5f;
    private float intScaling = 0.5f;

    public ManaReave(Enemy enemy, int duration)
    {
        Target = enemy;
        Player = FindObjectOfType<Player>();
        SetDuration(duration);
        DebuffSprite = Target.ManaReaveSpirte;
        DebuffTimer = Target.ManaReaveTimer;
        if(DebuffSprite != null)
        {
            DebuffSprite.enabled = true;
            DebuffTimer.text = duration.ToString();
        }
        Name = "Mana Reave";
    }

    public override void TriggerEffect()
    {   
        if(GetActive())
        {
            Target.DecCurrentHP(baseTriggerDamage + Mathf.RoundToInt(Player.GetIntelligence()*intScaling));
            Player.IncCurrentMana(manaRefund);
            SetActive(false);
            base.TriggerEffect();     
        }
    }

    public override void TickEffect()
    {
        Target.DecCurrentHP(baseTickDamage + Mathf.RoundToInt(Player.GetMind()*mindScaling));
        if(DebuffTimer != null)
        {
            DebuffTimer.text = GetDuration().ToString();
        }
    }

    #region Getter/Setter

    public float GetScaling(string stat)
    {
        switch(stat)
        {
            case "Mind":
                return mindScaling;
            case "Int":
                return intScaling;
            default:
                Debug.Log("Invalid scaling! Returning IntScaling!");
                return intScaling;
        }
    }

    public void SetScaling(string stat, float scaling)
    {
        switch(stat)
        {
            case "Mind":
                mindScaling = scaling;
                break;
            case "Int":
                intScaling = scaling;
                break;
            default:
                Debug.Log("Invalid scaling!");
                break;
        }
    }

    public int GetDamage(string type)
    {
        switch(type)
        {
            case "Trigger":
                return baseTriggerDamage;
            case "Tick":
                return baseTickDamage;
            default:
                Debug.Log("Invalid Type!");
                return 0;
        }
    }

    public void SetDamage(string type, int damage)
    {
        switch(type)
        {
            case "Trigger":
                baseTriggerDamage = damage;
                break;
            case "Tick":
                baseTickDamage = damage;
                break;
            default:
                Debug.Log("Invalid Type!");
                break;
        }
    }

    public int GetRedund()
    {
        return manaRefund;
    }

    public void SetRefund(int refund)
    {
        manaRefund = refund;
    }
    #endregion
}
