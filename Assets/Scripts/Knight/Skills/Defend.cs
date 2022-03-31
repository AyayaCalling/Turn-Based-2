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
   public void UsingDefend()
    {
        Debug.Log("Using Defend");
        blockMod = Mathf.RoundToInt(player.GetDexterity() * 0.5f);
        blockGiven += baseBlock + blockMod;

        player.SetBlock(blockGiven);

        Debug.Log("Current Block: " + player.GetBlock().ToString());
        Debug.Log("Block Given: " + blockGiven.ToString());
        
    }
}
