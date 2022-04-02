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

    private BattleState state = BattleState.PlayerTurn;

    private List<Enemy> enemies = new List<Enemy>();

    //These methods change the current Battlestate.
    #region StateChanges

    public void ChangeStateToPlayerTurn()
    {
        SkillOneButton.interactable = true;
        SkillTwoButton.interactable = true;
        SkillThreeButton.interactable = true;

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

        state = BattleState.EnemyTurn;
        Player.SetActive(false);

            foreach(Enemy enemy in enemies)
            {
               Debug.Log(enemy + "'s Move!");     
            }

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

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }



    
}
