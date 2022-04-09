using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the parent class for all enemies in the game.
public class Enemy : MonoBehaviour
{
    private int currentHP = 100;
    private int maxHP = 100;

    private int block;

    //This variable displays the turn the enemy is already on in its cycle.
    private int turnNumber = 1;

    //This is the Randomly Generated Number, that decides what the enemy will do.
    private int move;

    //These variables are used to shift Hp Bar and Target Button to match the current enemy position.
    private float scaleSlider;
    private float scaleButton; 

    private Battlesystem Battle;

    public Transform EnemyTrans;

    public GameObject EnemyObj;

    public RectTransform buttonRect;
    public RectTransform sliderRect;
    public RectTransform intentionRect;

    private Vector3 posButton;
    private Vector3 posSlider;
    private Vector3 posIntention;

    private int buttonY = 30;
    private int sliderY = 230;
    private int intentionY = 130;

    //This variable displays the player, the enemy currently targets.
    public Player Player;

    //All HUD Objects related to the enemy.
    public Button button;

    public Text IntentionText;
    public Text BlockText;

    public Image AttackIntention;
    public Image FixDamageIntention;
    public Image BuffIntention;
    public Image DebuffIntention;

    //This method shifts all UI elements to match the enemy's position and finds a default attack Target.
    public void Start()
    {
        button.onClick.AddListener(TargetClick);

        Debug.Log("Initiating Battle Mode!");

        Battle = GameObject.FindWithTag("Player").GetComponent<Battlesystem>();

        Battle.AddEnemy(this);

        Player = FindObjectOfType<Player>();

        switch(EnemyTrans.position.x)
        {
            case -7:
                posButton = new Vector3 (-265, buttonY, 0);
                posSlider = new Vector3 (-265, sliderY, 0);
                posIntention = new Vector3 (-265, intentionY, 0);
                break;

            case -4:
                posButton = new Vector3 (-135, buttonY, 0);
                posSlider = new Vector3 (-135, sliderY, 0);
                posIntention = new Vector3 (-135, intentionY, 0);
                break;

            case -1:
                posButton = new Vector3 (0, buttonY, 0);
                posSlider = new Vector3 (0, sliderY, 0);
                posIntention = new Vector3 (0, intentionY, 0);
                break;

            case 2:
                posButton = new Vector3 (135, buttonY, 0);
                posSlider = new Vector3 (135, sliderY, 0);
                posIntention = new Vector3 (135, intentionY, 0);
                break;

            case 5:
                posButton = new Vector3 (265, buttonY, 0);
                posSlider = new Vector3 (265, sliderY, 0);
                posIntention = new Vector3 (265, intentionY, 0);
                break;

            default:
                Debug.Log("There shouldn't be an enemy in this location");
                break;
        }

        buttonRect.anchoredPosition = posButton;
        sliderRect.anchoredPosition = posSlider;
        intentionRect.anchoredPosition = posIntention;
    }

    // Setter-Method for the Variable currentHP. (only used in the initialization publicly)
    public void SetCurrentHP(int hp)
    {
        currentHP = hp;
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

    // Getter-Method for the Variable currentHP.
    public int GetCurrentHP()
    {
        return currentHP;
    }

    public int GetBlock()
    {
        return block;
    }

    public void SetBlock(int value)
    {
        block = value;
        BlockText.text = block.ToString();
    }

    public void DecCurrentHP(int minusHP)
    {
        int hp = GetCurrentHP() - minusHP;
        if (hp <= 0)
        {
            SetCurrentHP(0);

            Die();
        }
        else 
        {
            SetCurrentHP(hp);
        }        

    } 

    public void IncBlock(int amount)
    {
        block += amount;
        BlockText.text = block.ToString();
    }

    public void DecBlock(int amount)
    {
        block -= amount;
        BlockText.text = block.ToString();
    }

    public int GetMove()
    {
        return move;
    }

    public void SetMove(int number)
    {
        move = number;
    }
   
    public void SetTurnNumber(int turn)
    {
        turnNumber = turn;
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }

    public Battlesystem GetBattle()
    {
        return Battle;
    }
    
    //This method kills and destroys the enemy if its HP reaches zero.
    public virtual void Die()
    {
        Battle.RemoveEnemy(this);
        Player.IncLevelToSpent(5);
        Destroy(EnemyObj);
    }

    //This method displays what the enemy will do on its next turn.
    public virtual void Intentions()
    {
        switch(turnNumber)
        {
            default:
                Debug.Log("This turn does not exist!");
                break;
            
            case 1:
                Debug.Log(this + "will deal 10 Damage.");
                Battle.MarkFloor(true, true, true, true, true);
                break;
            
            case 2:
                Debug.Log(this + "will deal 5 Damage");
                Battle.MarkFloor(true, true, true, true, true);
                break;

            case 3:
                Debug.Log(this + "will make you weak for 2 and vulnerable for 1 turn(s)");
                break;
        }
    }

    //This method cycles the enemy's turns. Its virtual so it can be overwritten by children of the class.
    public virtual void  Move()
    {
        switch(turnNumber)
        {
            case 1:
            Battle.DealDamageToPlayer(Player, 10);
            turnNumber = 2;
            break;

            case 2:
            Battle.DealDamageToPlayer(Player, 5);
            turnNumber = 3;
            break;

            case 3:
            Player.SetWeakness(0.3f);
            Player.SetWeakTurns(2);
            Player.SetVulnerable(2f);
            Player.SetVulnerableTurns(2);
            //Object.Instantiate(EnemyObj, new Vector3(-5, 0, 10), new Quaternion(0, 0, 0, 0));
            turnNumber = 1;
            break;
        }
    }

    public void TargetClick()
    {
        Player.GetComponent<TargettingSystem>().TargetThisEnemy(this);
    }

}



