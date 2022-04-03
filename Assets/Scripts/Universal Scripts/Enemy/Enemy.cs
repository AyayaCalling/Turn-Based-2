using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the parent class for all enemies in the game.
public class Enemy : MonoBehaviour
{
    private int currentHP = 100;
    private int maxHP = 100;

    //This variable displays the turn the enemy is already on in its cycle.
    private int turnNumber = 1;

    //These variables are used to shift Hp Bar and Target Button to match the current enemy position.
    private float scaleSlider;
    private float scaleButton; 

    public Battlesystem Battle;

    public Transform EnemyTrans;

    public GameObject EnemyObj;

    public RectTransform buttonRect;
    public RectTransform sliderRect;

    private Vector3 posButton;
    private Vector3 posSlider;

    private int buttonY = 30;
    private int sliderY = 230;

    //This variable displays the player, the enemy currently targets.
    public Player Player;

    //This variable stores all information a basic enemy needs to be created in game.
    

    //This method shifts all UI elements to match the enemy's position and finds a default attack Target.
    public void Start()
    {
        Battle.AddEnemy(this);

        Player = FindObjectOfType<Player>();

        switch(EnemyTrans.position.x)
        {
            case -5:
            posButton = new Vector3 (-180, buttonY, 0);
            posSlider = new Vector3 (-180, sliderY, 0);
            break;

            case -2:
            posButton = new Vector3 (-50, buttonY, 0);
            posSlider = new Vector3 (-50, sliderY, 0);
            break;

            case -1:
            posButton = new Vector3 (0, buttonY, 0);
            posSlider = new Vector3 (0, sliderY, 0);
            break;

            case 1:
            posButton = new Vector3 (85, buttonY, 0);
            posSlider = new Vector3 (90, sliderY, 0);
            break;

            case 4:
            posButton = new Vector3 (225, buttonY, 0);
            posSlider = new Vector3 (220, sliderY, 0);
            break;
        }

        buttonRect.anchoredPosition = posButton;
        sliderRect.anchoredPosition = posSlider;
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

    //This method kills and destroys the enemy if its HP reaches zero.
    public void Die()
    {
        Battle.RemoveEnemy(this);
        Destroy(EnemyObj);
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
            Debug.Log("This will later put a Debuff on the Player.");
            Object.Instantiate(EnemyObj, new Vector3(-5, 0, 10), new Quaternion(0, 0, 0, 0));
            turnNumber = 1;
            break;
        }
    }
}


