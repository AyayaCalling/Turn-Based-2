using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This Class contains the basic variables and methods for Defending/ Blocking in the game.
U21:Spiky Shield. Getting hit while having block reflects some damage.
U22:Heavy Armor. Increases dex scaling.
U23:Reinforced Defense. Prevents the first damage that breaks your shield.
U31:Shimmering Scales. Blocking cleanses all your debuffs.
U32:Selfrepairing Armor. If your block reduced to 0 this turn, gain the same amount of block next turn.
U33:Explosive Steel. When a hit reduces your Block to 0 you explode, dealing AoE damage to everyone excluding yourself.
*/
public class Defend : Skill
{
    #region Variables


    private bool u22Applied = false;

    private int spikeDamage = 5;

    // This variable is the basic amount of Block you get, while not having any modifiers.
    private static int baseBlock = 5;

    private int scaledBlock;
    private int totalBlock;

    // This variable describes the amount of bonus Block the player gets, wehen using the Defend Mechanic.
    private int blockMod = 0;

    private float dexScaling = 0.5f;

    //These variables handle Manacost of different Upgrades.
    private int Cost21 = 30;
    private int Cost22 = 40;
    private int Cost23 = 35;
    private int Cost31 = 35;
    private int Cost32 = 45;
    private int Cost33 = 40;

    #endregion

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            UsingDefend();
        }
    }
    //

    public void Awake()
    {
        SetUpgradeScaling(22, 0.75f);
        manaCostText.text = GetManaCost().ToString();
    }
    #region GetterAndSetter

    // Getter-Method for the Variable baseBlock.
    public int GetBase()
    {
        return baseBlock;
    }

    public int GetScaled()
    {
        return scaledBlock;
    }

    public void SetScaled(int value)
    {
        scaledBlock = value;
    }

    public float GetScaling()
    {
        return dexScaling;
    }

    public void SetScaling(float value)
    {
        dexScaling = value;
    }

    // Setter-Method for the vraiable blockMod.
    public void SetBlockMod(int newBlock)
    {
        blockMod = newBlock;
    }

    // Getter-Method for the variable blockMod.
    public int GetBlockMod()
    {
        return blockMod;
    }

    public void SetTotalBlock(int amount)
    {
        totalBlock = amount;
    }

    public int GetTotalBlock()
    {
        return totalBlock;
    }

    public void SetSpikeDamage(int damage)
    {
        spikeDamage = damage;
    }

    public int GetSpikeDamage()
    {
        return spikeDamage;
    }
   
   #endregion

    #region Inc/Dec-Methods

    // This Method is to increase the variable blockMod (e.g. Items that increase blockmod aside from dexterity).
    public void IncBlockMod(int addedBlock)
    {
        blockMod += addedBlock;
    }

    #endregion

    #region UseDefendMethod

   // This method uses Mana to give a certain amount of block (If not enough Mana, displays an error message).
   public void UsingDefend()
    {
        if (Player.GetCurrentMana() > 0 && Player.GetActive())
        {
            Player.DecCurrentMana(GetManaCost());
            
            ModifyDefend();

            Player.IncBlock(GetTotalBlock());

            observer.ManaValueChange();
        }
        else
        {
            Debug.Log("No Mana for this!");
        }

        Scaler.SkillOne.SetLastUsed(false);
    }

    public void ModifyDefend()
    {
        if(GetUpgrade22() && !u22Applied)
        {
            dexScaling = GetUpgradeScaling(22);
            u22Applied = true;
        }

        SetTotalBlock(GetBase() + Mathf.RoundToInt(Player.GetDexterity() * dexScaling) + GetBlockMod());
    }
    #endregion

    #region Overrides
    public override void SetUpgrade(int iD, bool state)
    {
        base.SetUpgrade(iD, state);

        if(iD == 21)
        {
            SetScaling(GetUpgradeScaling(21));
        }
    }
    #endregion

}
