using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class moves the player across the playing Field. The Field contains 5 Tiles.
public class Dodge : MonoBehaviour 
{

    public Button SkillButton;

    public Button TileOne;
    public Button TileTwo;
    public Button TileThree;
    public Button TileFour;
    public Button TileFive;

    public Transform TileOneTrans;
    public Transform TileTwoTrans;
    public Transform TileThreeTrans;
    public Transform TileFourTrans;
    public Transform TileFiveTrans;

    private Button tempButton;

    private List<Button> buttons = new List<Button>();

    private List<Transform> buttonTrans = new List<Transform>();
    private List<Transform> availableButtonTrans = new List<Transform>();

    public Player Player;
    public CharacterController PlayerController; 
    private Vector3 rollPos;

    private int rollRange = 1;

    private int manaCost = 1;

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

    //This method detemines which Tiles will be in range for the Skill.
    public void UsingDodge()
    {
        if (Player.GetCurrentMana() < 1)
        {
            return;
        }else if (Player.GetActive())
        {

            SkillButton.interactable = false;
            
            foreach(Transform trans in buttonTrans)
            {
                if ((Mathf.Abs(Player.transform.position.x - trans.position.x) <= rollRange) && (Mathf.Abs(Player.transform.position.x - trans.position.x) != 0))
                {
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

    //This method will use one mana to transport the player to the destined position.
    public void Activation(int posX)
    {
        posX = posX - Mathf.RoundToInt(transform.position.x);

        rollPos = new Vector3(posX, 0, 0);

        PlayerController.Move(rollPos);

        rollPos = new Vector3(0, 0, 0);

        availableButtonTrans.Clear();

        foreach(Button button in buttons)
        {
            button.interactable = false;
        }

        SkillButton.interactable = true;

        Player.DecCurrentMana(manaCost);
    }

}


