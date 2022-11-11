using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    // This variable describes the current instance of the player.
    public Player Player;

    //This variable describes the Button that needs to be pressed, to trigger the Skill-Activation.
    public Button SkillButton;

    //This variable stores information for the Skills mana cost.
    private int manaCost = 30;
    public Text manaCostText;

    //This varibale constantly checks for availability of the Skill.
    public ManaObserver observer;

    //These variables scale the Skilldamage the player will deal.
    public DamageScaler Scaler;
    private int baseDamage;
    private int statDamage;
    private int itemDamage;
    private int totalDamage;

    private bool lastUsed;

    //These bools handle Skill-Upgrade-Tracking
    private bool u2P1 = false;
    private bool u2P2 = false;
    private bool u2P3 = false;
    private bool u3P1 = false;
    private bool u3P2 = false;
    private bool u3P3 = false;

    //These variables determine scalings of Skill Upgrades.
    private float u21Scaling;
    private float u22Scaling;
    private float u23Scaling;
    private float u31Scaling;
    private float u32Scaling;
    private float u33Scaling;

    #region Roll Mech

    public Button TileOne;
    public Button TileTwo;
    public Button TileThree;
    public Button TileFour;
    public Button TileFive;
    
    public Transform playerTrans;

    public Transform TileOneTrans;
    public Transform TileTwoTrans;
    public Transform TileThreeTrans;
    public Transform TileFourTrans;
    public Transform TileFiveTrans;

    private List<Button> buttons = new List<Button>();

    private List<Transform> buttonTrans = new List<Transform>();
    private List<Transform> availableButtonTrans = new List<Transform>();

    public CharacterController PlayerController; 
    private Vector3 rollPos;

    #endregion

    //These methods set and get different values of "Strike".
    #region Setter/Getter

    public void SetButtons(List<Button> buttonList)
    {
        buttons = buttonList;
    }

    public List<Button> GetButtons()
    {
        return buttons;
    }

    public void SetTrans(List<Transform> transList ,string switchString)
    {
        switch(switchString)
        {
            case "available":
                availableButtonTrans = transList;
                break;
            case "standard":
                buttonTrans = transList;
                break;
            default:
                buttonTrans = transList;
                break;
        }
    }

    public void AddTrans(Transform trans ,string switchString)
    {
        switch(switchString)
        {
            case "available":
                availableButtonTrans.Add(trans);
                break;
            case "standard":
                buttonTrans.Add(trans);
                break;
            default:
                buttonTrans.Add(trans);
                break;
        }
    }

    public List<Transform> GetTrans(string switchString)
    {
        switch(switchString)
        {
            case "available":
                return availableButtonTrans;
            case "standard":
                return buttonTrans;
            default:
                Debug.Log("Wrong String input!");
                return buttonTrans;
        }
    }

    public void SetRollPos(Vector3 pos)
    {
        rollPos = pos;
    }

    public Vector3 GetRollPos()
    {
        return rollPos;
    }
    public void SetBaseDamage(int dmg)
    {
        baseDamage = dmg;
    }

    public int GetBaseDamage()
    {
        return baseDamage;
    }

    public void SetStatDamage(int physDmg, int magicDmg)
    {
        statDamage = physDmg + magicDmg;
    }

    public int GetStatDamage()
    {
        return statDamage;
    }

    public void SetItemDamage(int dmg)
    {
        itemDamage = dmg;
    }

    public int GetItemDamage()
    {
        return itemDamage;
    }
    
    public bool GetUpgrade21()
    {    
        return u2P1;
    }

    public bool GetUpgrade22()
    {    
        return u2P2;
    }

    public bool GetUpgrade23()
    {    
        return u2P3;
    }

    public bool GetUpgrade31()
    {    
        return u3P1;
    }

    public bool GetUpgrade32()
    {    
        return u3P2;
    }

    public bool GetUpgrade33()
    {    
        return u3P3;
    }

    public virtual void SetUpgrade(int iD, bool state)
    {    
        switch(iD)
        {
            case 21:
                u2P1 = state;
                break;
            case 22:
                u2P2 = state;
                break;
            case 23:
                u2P3 = state;
                break;
            case 31:
                u3P1 = state;
                break;
            case 32:
                u3P2 = state;
                break;
            case 33:
                u3P3 = state;
                break;
            default:
                Debug.Log("There's no such Upgrade!");
                break;
        }
    }

    public float GetUpgradeScaling(int iD)
    {
        switch(iD)
        {
            case 21:
                return u21Scaling;
            case 22:
                return u22Scaling;                
            case 23:
                return u23Scaling;                
            case 31:
                return u31Scaling;
            case 32:
                return u32Scaling;
            case 33:
                return u33Scaling;
            default:
                Debug.Log("There's no such Upgrade!");
                return 0;

        }
    }
    
    public void SetUpgradeScaling(int iD, float scaleValue)
    {
        switch(iD)
        {
            case 21:
                u21Scaling = scaleValue;
                break;
            case 22:
                u22Scaling = scaleValue;
                break;
            case 23:
                u23Scaling = scaleValue;
                break;
            case 31:
                u31Scaling = scaleValue;
                break;
            case 32:
                u32Scaling = scaleValue;
                break;
            case 33:
                u33Scaling = scaleValue;
                break;
            default:
                Debug.Log("There's no such Upgrade!");
                break;   
        }
    }

    //Getter-Method for the Skills mana cost
    public int GetManaCost()
    {
        return manaCost;
    }

    //Setter-Method for the Skills mana cost
    public void SetManaCost(int cost)
    {
        manaCost = cost;
    }

    public void SetLastUsed(bool state)
    {
        lastUsed = state;
    }

    public bool GetLastUsed()
    {
        return lastUsed;
    }   

    public void SetTotalDamage(int value)
    {
        totalDamage = value;
    }

    public int GetTotalDamage()
    {
        return totalDamage;
    }
    #endregion

    //These methods increase and decrease different values of "Strike"
    #region  Inc/Dec

    public void IncBaseDamage(int dmg)
    {
        baseDamage += dmg;
    }

    public void DecBaseDamage(int dmg)
    {
        baseDamage -= dmg;
    }

    public void IncStatDamage(int dmg)
    {
        statDamage += dmg;
    }

    public void DecStatDamage(int dmg)
    {
        statDamage -= dmg;
    }

    public void IncItemDamage(int dmg)
    {
        itemDamage += dmg;
    }   

    public void DecItemDamage(int dmg)
    {
        itemDamage -= dmg;
    }
    #endregion

    public virtual void UpdateManaCost(int iD)
    {
        manaCostText.text = manaCost.ToString();
    }

    public virtual void UpdateUI()
    {
        
    }
}
