using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Class contains the basic variables and methods for Attacking/ Striking in the game.
public class Strike : MonoBehaviour
{
    #region Variables

    // This variable describes the current instance of the player.
    public Player Player;

    // These variables are used to display and calculate the battle phase.
    public TargettingSystem targetter;
    public Battlesystem battle;

    // This variable descrobes the manCost of using Strike.
    private readonly int manaCost = 1;

    #endregion

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
                battle.DealDamageToEnemy(targetter.target, 10);

                Player.DecCurrentMana(manaCost);
            }
        }
        else
        {
            Debug.Log("Please select a valid target!");
        }
    }

    #endregion

}
