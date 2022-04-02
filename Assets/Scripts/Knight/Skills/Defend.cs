using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Class contains the basic variables and methods for Defending/ Blocking in the game.
public class Defend : MonoBehaviour
{
    #region Variables

    // This variable stores the values and actions of the player.
    public Player player;

    // This variable is the basic amount of Block you get, while not having any modifiers.
    private static int baseBlock = 5;

    // This variable describes the amount of bonus Block the player gets, wehen using the Defend Mechanic.
    private int blockMod = 0;

    #endregion

    #region GetterAndSetter

    // Getter-Method for the Variable baseBlock.
    public int GetBase()
    {
        return baseBlock;
    }

    // Setter-Method for the vraiable blockMod.
    public void SetBlockMod(int newBlock)
    {
        blockMod = newBlock;
    }

    // Getter-Method for the variable blockMod.
    public int GetBlockMod()
    {
        return blockMod;
    }
   
   #endregion

    #region Inc/Dec-Methods

    // This Method is to increase the variable blockMod (e.g. Items that increase blockmod aside from dexterity).
    public void IncBlockMod(int addedBlock)
    {
        blockMod += addedBlock;
    }

    #endregion

    #region UseDefendMethod

   // This method uses one Mana to give a certain amount of block (If not enough Mana, displays an error message).
   public void UsingDefend()
    {
        if (player.GetCurrentMana() > 0)
        {
            player.SetCurrentMana(player.GetCurrentMana() -1);
            
            Debug.Log("Using Defend");

            blockMod = Mathf.RoundToInt(player.GetDexterity() * 0.5f);
            
            player.IncBlock((GetBase() + blockMod));

            Debug.Log("Current Block: " + player.GetBlock().ToString());
            Debug.Log("Block Given: " + (baseBlock + blockMod).ToString());

        }else
        {
            Debug.Log("No Mana for this!");
        }
    }

    #endregion

}
