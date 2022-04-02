using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    #region Variables

    public Player Player;

    public TargettingSystem targetter;
    public Battlesystem battle;

    private int manaCost = 1;

    #endregion

    public void UsingStrike()
    {
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
            Debug.Log("Please select a target!");
        }
    }
}
