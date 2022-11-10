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
        DebuffSprite.enabled = true;
        DebuffTimer.text = duration.ToString();
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
        DebuffTimer.text = GetDuration().ToString();
    }

}
