using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Class contains the basic variables and methods for Dodging/ Rolling in the game.
// It moves the player across the playing Field. The Field contains 5 tiles (1|2|3|4|5).
public class Dodge : Skill 
{
    // BRAUCHT KOMMENTARE
    #region Variables
    private float rollRange = 1.2f;

    #endregion

    #region InitializeTiles

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            UsingDodge();
        }
    }
    // This Method initializes the Lists with all needed Buttons.
    public void Awake()
    {
        manaCostText.text = GetManaCost().ToString();
        
        GetButtons().Add(TileOne);
        GetButtons().Add(TileTwo);
        GetButtons().Add(TileThree);
        GetButtons().Add(TileFour);
        GetButtons().Add(TileFive);

        GetTrans("standard").Add(TileOneTrans);
        GetTrans("standard").Add(TileTwoTrans);
        GetTrans("standard").Add(TileThreeTrans);
        GetTrans("standard").Add(TileFourTrans);
        GetTrans("standard").Add(TileFiveTrans);
    }

    #endregion

    // BRAUCHT KOMMENTARE
    #region UseDodgeMethod

    //This method detemines which Tiles will be in range for the Skill.
    public void UsingDodge()
    {
        if (Player.GetCurrentMana() < 1)
        {
            return;
        }
        else if (Player.GetActive())
        {
            foreach(Transform trans in GetTrans("standard"))
            {
                if ((Mathf.Abs(Player.transform.position.x - trans.position.x) <= rollRange) && (Mathf.Abs(Player.transform.position.x - trans.position.x) > 0.1))
                {
                    Debug.Log("The absolute distance to this tile, " + trans + " is calculated as: " + Mathf.Abs(Player.transform.position.x - trans.position.x));
                    List<Transform> tempTrans = new List<Transform>();
                    tempTrans.Add(trans);
                    
                    foreach(Transform tile in tempTrans)
                    {
                        Debug.Log("The following tile has been added to the List: " + tile);
                    }
                    
                    AddTrans(trans, "available");
                }
            }


            foreach(Transform trans in GetTrans("available"))
            {
                Button tempButton = trans.GetComponentInChildren<Button>();
                tempButton.interactable = true;
            }
        }

        Scaler.SkillOne.SetLastUsed(false);
    }

    #endregion

    // BRAUCHT KOMMENTARE
    #region ActivationMethod

    //This method will use one mana to transport the player to the destined position.
    public void Activation(int posX)
    {
        posX = posX - Mathf.RoundToInt(playerTrans.position.x);

        SetRollPos(new Vector3(posX, 0, 0));

        PlayerController.Move(GetRollPos());
        
        SetRollPos(new Vector3(0, 0, 0));

        GetTrans("available").Clear();

        foreach(Button button in GetButtons())
        {
            button.interactable = false;
        }

        SkillButton.interactable = true;

        Player.DecCurrentMana(GetManaCost());

        observer.ManaValueChange();
    }

    #endregion

}