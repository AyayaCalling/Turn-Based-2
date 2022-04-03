using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int currentHP = 100;
    private int maxHP = 100;

    private int turnNumber = 1;

    private float scaleSlider;
    private float scaleButton; 

    public Battlesystem Battle;

    public Transform EnemyTrans;

    public GameObject EnemyObj;

    public Player Player;

    public RectTransform buttonRect;
    public RectTransform sliderRect;

    private Vector3 posButton;
    private Vector3 posSlider;
    
    public void Start()
    {
        Battle.AddEnemy(this);

        Player = FindObjectOfType<Player>();

        scaleButton = EnemyTrans.position.x * 25;
        scaleSlider = EnemyTrans.position.x * 30;

        posButton = new Vector3 (scaleButton, 100, 0);
        posSlider = new Vector3 (scaleSlider, 300, 0);

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

    public void Die()
    {
        Battle.RemoveEnemy(this);
        Destroy(EnemyObj);
    }

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
            turnNumber = 1;
            break;
        }
    }
}


