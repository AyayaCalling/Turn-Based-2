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

    Vector3 doorPos = new Vector3(0, 590, 50);

    public Transform doorParent;

    private GameObject doorObj;
    

    //This method creates the exit doors after a won battle
    public void CreateRandomExits(int amount)
    {    
        HUD.RemoveOldDoors();

        for(int i = 0; i < amount; i++)
        {
            int doorType = Random.Range(1,4);

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
            }
            switch(doorType)
            {
                case 1:
                    Object.Instantiate(FightDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;

                case 2:
                    Object.Instantiate(RestDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;

                case 3:
                    Object.Instantiate(EventDoor, doorPos, new Quaternion(0, 0, 0, 0), doorParent);
                break;
            }  
        }

    }
}
