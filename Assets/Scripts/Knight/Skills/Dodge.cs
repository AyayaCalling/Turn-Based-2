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

    public Button TileOne;
    public Button TileTwo;
    public Button TileThree;
    public Button TileFour;
    public Button TileFive;
    
    public Transform playerTrans;

    public Transform TileOneTrans;
    public Transform TileTwoTrans;
    public Transform TileThreeTrans;
    public Transform TileFourTrans;
    public Transform TileFiveTrans;

    private Button tempButton;

    private List<Button> buttons = new List<Button>();

    private List<Transform> buttonTrans = new List<Transform>();
    private List<Transform> availableButtonTrans = new List<Transform>();

    public CharacterController PlayerController; 
    private Vector3 rollPos;

    private float rollRange = 1.2f;

    #endregion

    #region InitializeTiles

    // This Method initializes the Lists with all needed Buttons.
    public void Awake()
    {
        buttons.Add(TileOne);
        buttons.Add(TileTwo);
        buttons.Add(TileThree);
        buttons.Add(TileFour);
        buttons.Add(TileFive);

        buttonTrans.Add(TileOneTrans);
        buttonTrans.Add(TileTwoTrans);
        buttonTrans.Add(TileThreeTrans);
        buttonTrans.Add(TileFourTrans);
        buttonTrans.Add(TileFiveTrans);
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

            SkillButton.interactable = false;
            
            foreach(Transform trans in buttonTrans)
            {
                Debug.Log("The absolute distance to this tile, " + trans + " is calculated as: " + Mathf.Abs(Player.transform.position.x - trans.position.x));
                if ((Mathf.Abs(Player.transform.position.x - trans.position.x) <= rollRange) && (Mathf.Abs(Player.transform.position.x - trans.position.x) > 0.1))
                {
                    //Debug.Log("The absolute distance to this tile, " + trans + " is calculated as: " + Mathf.Abs(Player.transform.position.x - trans.position.x));
                    availableButtonTrans.Add(trans);
                }
            }

            foreach(Transform trans in availableButtonTrans)
            {
                tempButton = trans.GetComponentInChildren<Button>();
                tempButton.interactable = true;
            }
        }
    }

    #endregion

    // BRAUCHT KOMMENTARE
    #region ActivationMethod

    //This method will use one mana to transport the player to the destined position.
    public void Activation(int posX)
    {
        posX = posX - Mathf.RoundToInt(playerTrans.position.x);

        rollPos = new Vector3(posX, 0, 0);

        PlayerController.Move(rollPos);
        Debug.Log(rollPos);
        rollPos = new Vector3(0, 0, 0);

        availableButtonTrans.Clear();

        foreach(Button button in buttons)
        {
            button.interactable = false;
        }

        SkillButton.interactable = true;

        Player.DecCurrentMana(GetManaCost());

        observer.ManaValueChange();
    }

    #endregion

}