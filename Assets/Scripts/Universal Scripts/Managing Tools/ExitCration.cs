using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class creates different numbers and types of exits, depending on the room and game progression.
public class ExitCration : MonoBehaviour
{
     //These varialbes are used to create exit doors
    //private int amountOfPossibleExits = 3;
    //private int amountOfDoors = 2;
    public HUD HUD;

    public GameObject EventDoor;
    public GameObject FightDoor;
    public GameObject RestDoor;

    Vector3 doorPos = new Vector3(0, 540, 0);

    public Transform doorParent;

    private GameObject doorObj;
    

    //This method creates the exit doors after a won battle
    public void CreateTwoRandomExits()
    {
        for(int i = 0; i < 2; i++)
        {
            int doorType = Random.Range(1,3);

            switch(i)
            {
                case 0:
                    doorPos.x = 760;
                break;

                case 1:
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
