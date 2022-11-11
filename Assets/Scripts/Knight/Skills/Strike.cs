using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Class contains the basic variables and methods for Attacking/Striking in the game.
public class Strike : Skill
{
    #region Variables

    // These variables are used to display and calculate the battle phase.
    public TargettingSystem targetter;
    public Battlesystem battle;
    public StrikeDesc StrikeDesc;

    //Knight's Strike only variables:
    private bool u21Applied;
    private bool u22Applied;
    private int u23Stacks;
    private int maxStacks = 3;
    private float stackRatio = 0.2f;
    private int secondHitChance = 40;
    private int thirdHitChance = 80;
    private float secondHitRatio = 0.2f;
    private float thirdHitRatio = 0.1f;
    private float spinRatio = 0.2f;
    private float spinHitRatio = 0.8f;

    private int manaReaveDuration = 3;
    private float rollRange = 10;

    //These variables handle Manacost of different Upgrades.
    private int Cost21 = 30;
    private int Cost22 = 40;
    private int Cost23 = 35;
    private int Cost31 = 35;
    private int Cost32 = 45;
    private int Cost33 = 40;

    #endregion

    public void Awake()
    {
        manaCostText.text = GetManaCost().ToString();

        SetUpgradeScaling(21, 0.5f);
        SetUpgradeScaling(22, 1.5f);

        //Setting up the Roll mech for U3P2.
        GetButtons().Add(TileOne);
        GetButtons().Add(TileTwo);
        GetButtons().Add(TileThree);
        GetButtons().Add(TileFour);
        GetButtons().Add(TileFive);

        GetTrans("standard").Add(TileOneTrans);
        GetTrans("standard").Add(TileTwoTrans);
        GetTrans("standard").Add(TileThreeTrans);
        GetTrans("standard").Add(TileFourTrans);
        GetTrans("standard").Add(TileFiveTrans);

        StrikeDesc.UpdateDescription(111);
    }
//This method will trigger every action binded to the "Strike" skill of "Knight".
    #region UseStrikeMethod

    /* This Method simulates a Strike.
    /  The player deals damage to the chosen enemy. (if he has enough mana) */
    public void UsingStrike()
    {
        // Checks, if a chosen target is valid.
        if(targetter.target != null)
        {
            if(Player.GetCurrentMana() > 0 && Player.GetActive())
            {
                if(GetLastUsed() == false)
                {
                    u23Stacks = 0;
                    SetLastUsed(true);
                }

                ModifyStrike();

                battle.DealDamageToEnemy(targetter.target, GetTotalDamage());

                Player.DecCurrentMana(GetManaCost());

                observer.ManaValueChange();
            }
        }
        else
        {
            Debug.Log("Please select a valid target!");
        }
    }

    #endregion

    #region Upgrades

    public void ModifyStrike()
    {
        if(GetUpgrade21() && u21Applied == false)
        {
            Scaler.SetKnightStrikeMagicScaling(GetUpgradeScaling(21));
            Scaler.ScaleStatValue();
            u21Applied = true;
        }
        if(GetUpgrade22() && u22Applied == false)
        {
            Scaler.SetKnightStrikePhysScaling(GetUpgradeScaling(22));
            Scaler.ScaleStatValue();
            u22Applied = true;
        }

        float strikeDamage = (GetBaseDamage() + GetStatDamage() + GetItemDamage()) * (1-Player.GetWeakness());
        SetTotalDamage(Mathf.RoundToInt(strikeDamage));

        if(GetUpgrade23())
        {
            float damage23 = strikeDamage*(1+u23Stacks*stackRatio);
            if(GetLastUsed() && u23Stacks < maxStacks)
            {
                u23Stacks +=1;
            }
            SetTotalDamage(Mathf.RoundToInt(damage23));       
        }

        if(GetUpgrade31())
        {
            foreach(Debuff debuff in battle.GetDebuffs())
            {
                if(debuff.Target == targetter.target && debuff.Name == "Mana Reave")
                {
                    debuff.TriggerEffect();
                }
            }
            ManaReave manaReave = new ManaReave(targetter.target, manaReaveDuration);
            battle.DebuffEnemy(manaReave, targetter.target, manaReaveDuration);
        }

        if(GetUpgrade32())
        {
            /* Currently discarded, due to bad synergy with Knight's Kit.
            foreach(Transform trans in GetTrans("standard"))
                {
                    if ((Mathf.Abs(Player.transform.position.x - trans.position.x) <= rollRange) && (Mathf.Abs(Player.transform.position.x - trans.position.x) > 0.1))
                    {
                        Debug.Log("The absolute distance to this tile, " + trans + " is calculated as: " + Mathf.Abs(Player.transform.position.x - trans.position.x));
                        List<Transform> tempTrans = new List<Transform>();
                        tempTrans.Add(trans);
                        
                        foreach(Transform tile in tempTrans)
                        {
                            Debug.Log("The following tile has been added to the List: " + tile);
                        }
                        
                        AddTrans(trans, "available");
                    }
                }

                foreach(Transform trans in GetTrans("available"))
                {
                    Button tempButton = trans.GetComponentInChildren<Button>();
                    tempButton.interactable = true;
                }*/

                foreach(Enemy enemy in battle.GetEnemies())
                {
                    SetTotalDamage(Mathf.RoundToInt(GetTotalDamage()* spinRatio));
                    battle.DealDamageToEnemy(enemy, GetTotalDamage());
                    SetTotalDamage(Mathf.RoundToInt(strikeDamage * spinHitRatio));
                }
        }
        

        if(GetUpgrade33())
        {
            float damage33;
            int rNG = Random.Range(0, 100);
            if(GetUpgrade23())
            {
                u23Stacks -= 1;
                damage33 = strikeDamage*(1+u23Stacks*stackRatio);
            }else
            {
                damage33 = strikeDamage*(1+u23Stacks*stackRatio);
            }
            
            if(GetLastUsed() && u23Stacks < maxStacks && GetUpgrade23())
                {
                    u23Stacks +=1;
                }

            if(rNG >= secondHitChance)
            {
                damage33 += secondHitRatio*strikeDamage*(1+u23Stacks*stackRatio);
                if(GetLastUsed() && u23Stacks < maxStacks && GetUpgrade23())
                    {
                        u23Stacks +=1;
                    }
            }

            if(rNG >= thirdHitChance)
            {
                damage33 += thirdHitRatio*strikeDamage*(1+u23Stacks*stackRatio);
                if(GetLastUsed() && u23Stacks < maxStacks && GetUpgrade23())
                    {
                        u23Stacks +=1;
                    }
            }
            
            SetTotalDamage(Mathf.RoundToInt(damage33));
        }

        if(!GetUpgrade21() && !GetUpgrade22() && !GetUpgrade23())
        {
            SetTotalDamage(Mathf.RoundToInt(strikeDamage));
        }

    } 

    #endregion

    #region Overrides

    public override void UpdateManaCost(int iD)
    {
        switch(iD)
        {
            case 21:
                SetManaCost(Cost21);
                break;
            case 22:
                SetManaCost(Cost22);
                break;
            case 23:
                SetManaCost(Cost23);
                break;
            case 31:
                SetManaCost(Cost31);
                break;
            case 32:
                SetManaCost(Cost32);
                break;
            case 33:
                SetManaCost(Cost33);
                break;
            default:
                Debug.Log("Invalid Upgrade!");
                break;

        }

        base.UpdateManaCost(iD);
    }

    public override void UpdateUI()
    {
        if(!GetUpgrade31() && !GetUpgrade32() && !GetUpgrade33())
        {
            if(GetUpgrade21())
        {
            StrikeDesc.UpdateDescription(21);
            UpdateManaCost(21);
            Debug.Log("Updating UI");
        }else if(GetUpgrade22())
        {
            StrikeDesc.UpdateDescription(22);
            UpdateManaCost(22);
        }else if(GetUpgrade23())
            StrikeDesc.UpdateDescription(23);
            UpdateManaCost(23);
        }
        else if(GetUpgrade31())
        {   
            StrikeDesc.UpdateDescription(31);
            UpdateManaCost(31);
        }else if(GetUpgrade32())
        {
            StrikeDesc.UpdateDescription(32);
            UpdateManaCost(32);
        }else if(GetUpgrade33())
        {
            StrikeDesc.UpdateDescription(33);
            UpdateManaCost(33);
        }else
        {
            StrikeDesc.UpdateDescription(11);
        }
    }

    public override void SetUpgrade(int iD, bool state)
    {
        base.SetUpgrade(iD, state);
        if(iD == 21)
        {
            Scaler.SetKnightStrikeMagicScaling(GetUpgradeScaling(21));
        }
        if(iD == 22)
        {
            Scaler.SetKnightStrikePhysScaling(GetUpgradeScaling(22));
        }
        Scaler.ScaleStatValue();
        StrikeDesc.UpdateDescription(iD);
    }

    #endregion

    #region Getter/Setter

    public int GetMaxStacks()
    {
        return maxStacks;
    }

    public void SetMaxStacks(int stacks)
    {
        maxStacks = stacks;
    }

    public float GetStackRatio()
    {
        return stackRatio;
    }

    public void SetStackRatio(float ratio)
    {
        stackRatio = ratio;
    }

    #endregion
}

