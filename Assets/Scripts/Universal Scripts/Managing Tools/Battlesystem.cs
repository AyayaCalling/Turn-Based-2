using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlesystem : MonoBehaviour
{
    enum BattleState
    {
        PlayerTurn, EnemyTurn, Won, Lost, None
    }  

    public Player Player;

    private BattleState state = BattleState.PlayerTurn;


    //These methods change the current Battlestate.
    #region StateChanges

    public void ChangeStateToPlayerTurn()
    {
        state = BattleState.PlayerTurn;
        Player.SetActive(true);
        Player.SetBlock(0);
        Player.SetCurrentMana(Player.GetMaxMana());
    }

    public void ChangeStateToEnemyTurn()
    {
        state = BattleState.EnemyTurn;
        Player.SetActive(false);

        //Command to trigger all enemy attacks.

        ChangeStateToPlayerTurn();
    }

    public void ChangeStateToWon()
    {
        state = BattleState.Won;
        Player.SetActive(false);
    }

    public void ChangeStateToLost()
    {
        state = BattleState.Lost;
        Player.SetActive(false);
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
        ChangeStateToEnemyTurn();
    }

    //These methods deal damage to an enemy or player.
    public void DealDamageToEnemy(Enemy thisEnemy, int amount)
    {
        thisEnemy.DecCurrentHP(amount);
        Debug.Log("Dealt " + amount + " damage to Enemy " + thisEnemy);
    }

    public void DealDamageToPlayer(Player thisPlayer, int amount)
    {
        thisPlayer.DecCurrentHP(amount);
        Debug.Log("Dealt " + amount + " damage to Player " + thisPlayer);
    }



    
}
