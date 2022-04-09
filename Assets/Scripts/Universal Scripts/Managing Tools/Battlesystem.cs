using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battlesystem : MonoBehaviour
{
    #region Variables

    enum BattleState
    {
        PlayerTurn, EnemyTurn, Won, Lost, None
    }  
    //This variable stores all needed player info.
    public Player Player;

    //These variables describe Buttons, that need to be dis-/enabled
    public Button SkillOneButton;
    public Button SkillTwoButton;
    public Button SkillThreeButton;
    public Button EndTurnButton;

    //The used instance of the enum "Battlestate".
    private BattleState state = BattleState.PlayerTurn;

    //This List tracks the amount of enemies that currently are present in the game.
    private List<Enemy> enemies = new List<Enemy>();

    //This variable is a Game related object for the defeat screen.
    public GameObject DefeatScreen;

    //The class used to create all exits.
    public ExitCreation ExitCreation;

    public SceneHandler SceneHandler;

    #endregion

    public void Start()
    {
        ChangeStateToPlayerTurn();
    }
    //These methods change the current Battlestate to the following states...
    #region StateChanges

    //Player Turn
    public void ChangeStateToPlayerTurn()
    {
        foreach(Enemy enemy in enemies)
        {
            enemy.Intentions();
        }
        //Allows interaction with the skill buttons.
        SkillOneButton.interactable = true;
        SkillTwoButton.interactable = true;
        SkillThreeButton.interactable = true;
        EndTurnButton.interactable = true;

        state = BattleState.PlayerTurn;

        //Allows the player to take actions.
        Player.SetActive(true);

        //Resets the block value.
        Player.SetBlock(0);

        //Refills the mana to max capacity.
        Player.SetCurrentMana(Player.GetMaxMana());

    }

    //Enemy Turn
    public void ChangeStateToEnemyTurn()
    {
        foreach(Enemy enemy in enemies)
        {
            enemy.SetBlock(0);;
        }
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

    //Won Battle
    public void ChangeStateToWon()
    {
        state = BattleState.Won;

        Debug.Log("You won the Battle!");

        //Deactivates fighting actions.
        Player.SetActive(false);

        //This ensures the player does not have debuffs after leaving the fight.
        Player.SetVulnerableTurns(0);
        Player.SetWeakTurns(0);
        Player.SetWeakness(0);
        Player.SetVulnerable(1);
        //Player.SetPoisonTurns(0);

        if(SceneHandler.GetStage() < 20)
        //Creates Exits to continue the progession
        ExitCreation.CreateRandomExits(2);
        else 
        ExitCreation.CreateFixExit("Boss");
    }

    //Lost Battle
    public void ChangeStateToLost()
    {
        state = BattleState.Lost;
        Debug.Log("You lost the Battle!");

        //Disables player actions.
        Player.SetActive(false);

        //Disables all enemies to not interfere with the defeat screen.
        foreach(Enemy enemy in enemies)
        {
            enemy.EnemyObj.SetActive(false);
        }

        //Enables defeat screen.
        DefeatScreen.SetActive(true);
    }

    //No Battlestate (Nothing's happening here :<)
    public void ChangeStateToNone()
    {
        state = BattleState.None;
        Player.SetActive(false);
    }

    #endregion

    //Button-Method for the End-Turn Button.
    public void OnEndturn()
    {
        //Reduce all debuffs granted in the player by 1 turn. If the counter reaches 0, cleanses the debuff.
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
        if(amount > thisEnemy.GetBlock())
        {
            thisEnemy.DecCurrentHP(amount - thisEnemy.GetBlock());
            thisEnemy.SetBlock(0);
            Debug.Log("Dealt " + amount + " damage to Enemy " + thisEnemy);
            Debug.Log(enemies.Count);
            if(enemies.Count == 0)
            {
                ChangeStateToWon();
            }
        }

        else
        {
            thisEnemy.DecBlock(amount);
        }
    }

    public void DealDamageToPlayer(Player thisPlayer, int amount)
    {
        int damage = Mathf.RoundToInt((amount * Player.GetVulnerable() - Player.GetBlock()));

        if(damage > 0)
        {
            Player.DecCurrentHP(damage);
            Debug.Log("Dealt " + amount + " damage to Player " + thisPlayer);
        }
    }

    //These methods are used to update the "enemies" list.
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
