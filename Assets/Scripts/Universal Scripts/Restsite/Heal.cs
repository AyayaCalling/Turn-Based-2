using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class heals the player at restsites
public class Heal : MonoBehaviour
{
    public Player Player;

    private float healAmount = 0.3f;

    //This method executes the healing proccess.
    public void OnHealButton()
    {
        Player.IncCurrentHP(Mathf.RoundToInt(Player.GetMaxHP() * healAmount));
        Debug.Log("Player got healed for: " + Mathf.RoundToInt(Player.GetMaxHP() * healAmount));
    }
}
