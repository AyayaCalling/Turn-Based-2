using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defend : MonoBehaviour
{
    public Button useSkill;
    public Player player;

    private int baseBlock = 5;
    private int blockMod;
    private int blockGiven;

    public void SetBase(int block)
    {
        baseBlock = block;
    }

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
