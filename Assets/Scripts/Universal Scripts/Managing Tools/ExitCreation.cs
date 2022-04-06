using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class creates different numbers and types of exits, depending on the room and game progression.
public class ExitCreation : MonoBehaviour
{
    //These varialbes are used to create exit doors
    //private int amountOfPossibleExits = 3;
    //private int amountOfDoors = 2;
    public HUD HUD;

    public GameObject EventDoor;    //Type 3
    public GameObject FightDoor;    //Type 1
    public GameObject RestDoor;     //Type 2
    public GameObject BossDoor;     //Type 4

    Vector3 doorPos = new Vector3(0, 590, 50);

    public Transform doorParent;

    private GameObject doorObj;

    //Probabilities for each door to appear in int/100.
    private int probFight = 60;
    private int probRest = 20;
    private int probEvent = 20;

    //This method creates "amount" randomly generated door types.
    public void CreateRandomExits(int amount)
    {    
        HUD.RemoveOldDoors();

        for(int i = 0; i < amount; i++)
        {
            int doorType = Random.Range(1,101);

            switch(i)
            {
                case 0:
                    if(amount == 1)
                    {
                        doorPos.x = 960;
                    }
                    else
                    {
                        doorPos.x = 760;
                    }
                    break;

                case 1:
                    if(amount == 2)
                    {
                        doorPos.x = 1160;
                    }
                    else
                    {
                        doorPos.x = 960;
                    }   
                    break;

                case 2:
                    doorPos.x = 1160;
                    break;
                
                default:
                    Debug.Log("Too many or too few doors. Pls choose an amount between 1 and 3");
                    break;
            }
       
            if(doorType <= probFight) Object.Instantiate(FightDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
            if(probFight < doorType && doorType <= (probFight + probRest)) Object.Instantiate(RestDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
            if((probFight + probRest) < doorType) Object.Instantiate(EventDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
        }

    }

    //This creates one particular exit, based on the value of "doorType".
    public void CreateFixExit(string doorType)
    {
        HUD.RemoveOldDoors();

        doorPos.x = 960;

        switch(doorType)
        {
            case "Fight":
                Object.Instantiate(FightDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;

            case "Rest":
                Object.Instantiate(RestDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;

            case "Event":
                Object.Instantiate(EventDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;

            case "Boss":
                Object.Instantiate(BossDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;

            default:
                Debug.Log("I don't know that door.");
                break;
        }
    }
}
