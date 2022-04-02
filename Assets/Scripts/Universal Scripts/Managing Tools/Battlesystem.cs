using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlesystem : MonoBehaviour
{
    enum BattleState
    {
        PlayerTurn, EnemyTurn, Won, Lost, None
    }  

    public Player player;
    private BattleState state = BattleState.PlayerTurn;

   /* public void Update()
    {
        switch(state) 
        {
            case BattleState.PlayerTurn:
            Debug.Log("sdsd");
            break;

            default:
            Debug.Log("unexpected error");
            break;
        }
        DealDamageToPlayer(player, 1);
    } */

    //These methods change the current Battlestate.
    #region StateChanges

    public void ChangeStateToPlayerTurn()
    {
        state = BattleState.PlayerTurn;
        player.SetActive(true);
    }

    public void ChangeStateToEnemyTurn()
    {
        state = BattleState.EnemyTurn;
        player.SetActive(false);
    }

    public void ChangeStateToWon()
    {
        state = BattleState.Won;
        player.SetActive(false);
    }

    public void ChangeStateToLost()
    {
        state = BattleState.Lost;
        player.SetActive(false);
    }

    public void ChangeStateToNone()
    {
        state = BattleState.None;
        player.SetActive(false);
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
