using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Class contains the basic variables and methods for Defending/ Blocking in the game.
public class Defend : MonoBehaviour
{
    public Player player;

    private int baseBlock = 5;
    private int blockMod;
    private int blockGiven;

    // Setter-Method for the Variable baseBlock.
    public void SetBase(int block)
    {
        baseBlock = block;
    }

    // Getter-Method for the Variable baseBlock.
    public int GetBase()
    {
        return baseBlock;
    }
   
   // This method uses one Mana to give a certain amount of block (If not enough Mana, displays an error message).
   public void UsingDefend()
    {

        if (player.GetCurrentMana() > 0) {
            
            player.SetCurrentMana(player.GetCurrentMana() -1);
            
            Debug.Log("Using Defend");

            blockMod = Mathf.RoundToInt(player.GetDexterity() * 0.5f);
            blockGiven += baseBlock + blockMod;

            player.SetBlock(blockGiven);

            Debug.Log("Current Block: " + player.GetBlock().ToString());
            Debug.Log("Block Given: " + blockGiven.ToString());

        }else {

            Debug.Log("No Mana for this!");
            
        }

        
        
    }
}
