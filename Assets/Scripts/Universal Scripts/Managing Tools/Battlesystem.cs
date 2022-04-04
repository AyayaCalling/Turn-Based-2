using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battlesystem : MonoBehaviour
{
    enum BattleState
    {
        PlayerTurn, EnemyTurn, Won, Lost, None
    }  

    public Player Player;

    public Button SkillOneButton;
    public Button SkillTwoButton;
    public Button SkillThreeButton;
    public Button EndTurnButton;

    private BattleState state = BattleState.PlayerTurn;

    private List<Enemy> enemies = new List<Enemy>();

    //This variable is a Game related object for the defeat screen.
    public GameObject DefeatScreen;

    //These varialbes are used to create exit doors
    //private int amountOfPossibleExits = 3;
    //private int amountOfDoors = 2;
    public HUD HUD;

    public GameObject EventDoor;
    public GameObject FightDoor;
    public GameObject RestDoor;

    Vector3 doorPos = new Vector3(0, 540, 0);

    public Transform doorParent;

    private GameObject doorObj;

    //These methods change the current Battlestate.
    #region StateChanges

    public void ChangeStateToPlayerTurn()
    {
        SkillOneButton.interactable = true;
        SkillTwoButton.interactable = true;
        SkillThreeButton.interactable = true;
        EndTurnButton.interactable = true;

        state = BattleState.PlayerTurn;

        Player.SetActive(true);

        Player.SetBlock(0);

        Player.SetCurrentMana(Player.GetMaxMana());

    }

    public void ChangeStateToEnemyTurn()
    {
        SkillOneButton.interactable = false;
        SkillTwoButton.interactable = false;
        SkillThreeButton.interactable = false;
        EndTurnButton.interactable = false;

        state = BattleState.EnemyTurn;
        Player.SetActive(false);

            foreach(Enemy enemy in enemies)
            {
                enemy.Move();
                Debug.Log(enemy + "'s Move!");     
            }

        ChangeStateToPlayerTurn();
    }

    public void ChangeStateToWon()
    {
        state = BattleState.Won;
        Debug.Log("You won the Battle!");
        Player.SetActive(false);
        CreateExit();
    }

    public void ChangeStateToLost()
    {
        state = BattleState.Lost;
        Debug.Log("You lost the Battle!");
        Player.SetActive(false);
        foreach(Enemy enemy in enemies)
        {
            enemy.EnemyObj.SetActive(false);
        }
        DefeatScreen.SetActive(true);
    }

    public void ChangeStateToNone()
    {
        state = BattleState.None;
        Player.SetActive(false);
    }

    #endregion

    //Button-Method for the End-Turn Button.
    public void OnEndturn()
    {
        //Small Bug causes one Turn of vulerability loss. Debuff runs out before the enemies get a turn.
        Player.DecWeakTurns(1);

        if(Player.GetWeakTurns() == 0)
        {
            Player.SetWeakness(0);
        }

        Player.DecVulnerableTurns(1);

        if(Player.GetVulnerableTurns() == 0)
        {
            Player.SetVulnerable(1);
        }

        ChangeStateToEnemyTurn();
    }

    //These methods deal damage to an enemy or player.
    public void DealDamageToEnemy(Enemy thisEnemy, int amount)
    {
        thisEnemy.DecCurrentHP(amount);
        Debug.Log("Dealt " + amount + " damage to Enemy " + thisEnemy);
        Debug.Log(enemies.Count);
        if(enemies.Count == 0)
        {
            ChangeStateToWon();
        }
    }

    public void DealDamageToPlayer(Player thisPlayer, int amount)
    {
        thisPlayer.DecCurrentHP(Mathf.RoundToInt(amount * Player.GetVulnerable()));
        Debug.Log("Dealt " + amount + " damage to Player " + thisPlayer);
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }


    
    //This method creates the exit doors after a won battle
    public void CreateExit()
    {
        for(int i = 0; i < 2; i++)
        {
            int doorType = Random.Range(1,3);

            switch(i)
            {
                case 0:
                    doorPos.x = 760;
                break;

                case 1:
                    doorPos.x = 1160;
                break;
            }
            switch(doorType)
            {
                case 1:
                    Object.Instantiate(FightDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;

                case 2:
                    Object.Instantiate(RestDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;

                case 3:
                    Object.Instantiate(EventDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;
            }  
        }

    }
}
