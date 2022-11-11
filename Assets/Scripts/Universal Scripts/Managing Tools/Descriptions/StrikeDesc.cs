using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeDesc : Descriptions
{
    public Strike Strike;
    public DamageScaler Scaler;
    private string U2Desc;

    public override void Awake()
    {
        base.Awake();
        Headline.text = "Strike:";
        DescriptionText.text = "Strikes the targeted enemy for " 
        + Strike.GetBaseDamage().ToString() + " Base- and " 
        + Strike.GetStatDamage().ToString() + " scaling Physical damage (" + (Scaler.GetKnightStrikePhysScaling()* 100).ToString() + "% phys Damage scaling)";
    }

    public override async void UpdateDescription(int iD)
    {
        Enemy enemy = new Enemy();
        ManaReave manaReave = new ManaReave(enemy, 3);
        switch(iD)
        {
            case 11:
                Headline.text = "Strike:";
                DescriptionText.text = "Strikes the targeted enemy for " 
                + Strike.GetBaseDamage().ToString() + " base - and " 
                + Strike.GetStatDamage().ToString() + " scaling damage (" + (Scaler.GetKnightStrikePhysScaling()* 100).ToString() + "% physical Damage scaling).\nTotal: " 
                + (Strike.GetBaseDamage() + Strike.GetStatDamage());
                break;
            case 21:
                Headline.text = "Spellsword";
                DescriptionText.text = "Strikes the targeted enemy for "
                + Strike.GetBaseDamage().ToString() + " base - and " 
                + Strike.GetStatDamage().ToString() + " scaling damage (" + Scaler.GetKnightStrikePhysScaling()* 100 + "% physical + "
                + Scaler.GetKnightStrikeMagicScaling() * 100 + "% magic damage). \nTotal: "
                + (Strike.GetBaseDamage() + Strike.GetStatDamage());
                U2Desc = DescriptionText.text;
                break;
            case 22:
                Headline.text = "Slash";
                DescriptionText.text = "Strikes the targeted enemy for " 
                + Strike.GetBaseDamage().ToString() + " base - and " 
                + Strike.GetStatDamage().ToString() + " scaling damage (" + (Scaler.GetKnightStrikePhysScaling()* 100).ToString() + "% physical Damage scaling).\nTotal: " 
                + (Strike.GetBaseDamage() + Strike.GetStatDamage());
                U2Desc = DescriptionText.text;
                break;
            case 23:
                Headline.text = "Raging Blade";
                DescriptionText.text = "Strikes the targeted enemy for " 
                + Strike.GetBaseDamage().ToString() + " base - and " 
                + Strike.GetStatDamage().ToString() + " scaling damage (" + (Scaler.GetKnightStrikePhysScaling()* 100).ToString() + "% physical Damage scaling).\nTotal: " 
                + (Strike.GetBaseDamage() + Strike.GetStatDamage())
                + "\nSuccessive Hits apply ''Fury'' stacks on the User (max. " 
                + Strike.GetMaxStacks() + " Stacks)."/* \nEach Stack increases damage by "
                + Strike.GetStackRatio()*100 + "%."*/;
                U2Desc = DescriptionText.text;
                break;
            case 31:
                Headline.text = "Reaver";
            DescriptionText.text = U2Desc + "\nApplies ''Mana Reave'' debuff on the enemy"/*, dealing "
            +  manaReave.GetDamage("Tick") + " base - and " + Mathf.RoundToInt(Player.GetMind()*manaReave.GetScaling("Mind")) + " scaling Damage ("
            + (manaReave.GetScaling("Mind")*100) + "% Mind scaling) every turn." 
            +"\nHitting an enemy with an active ''Mana Reave'' debuff triggers it, dealing "
            + manaReave.GetDamage("Trigger") + " base - and " + Mathf.RoundToInt(Player.GetIntelligence()*manaReave.GetScaling("int"))
            + " scaling damage (" + manaReave.GetScaling("int")*100 + " % Int scaling)." 
            + "\nRefunds " + manaReave.GetRedund() + " Mana when triggered."*/;
                break;
            case 32:
                break;
            default:
                Debug.Log("Invalid Description ID!");
                break;
        }
    }

    public override void OnMouseOver()
    {
        base.OnMouseOver();
        Debug.Log("Displaying Description...");
    }

    public override void OnMouseExit()
    {
        base.OnMouseExit();
    }
}
