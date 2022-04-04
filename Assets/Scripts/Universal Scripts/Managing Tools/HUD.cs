using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    //This variable is used to destroy the Hud.
    public GameObject thisObj;

    //This variable is needed for the door destroying work around.
    private List<Door> doors = new List<Door>();

    //This method ensures, that the Hud will not be destroyed when loading new scenes.
    public void Awake()
    {
        DontDestroyOnLoad(thisObj);
    }

    //This method destroys the Hud if needed.
    public void DestroyHUD()
    {
        Destroy(thisObj);
    }

    //These methods are related to the door destroying work around.
    public void UpdateDoorList(Door door)
    {  
        doors.Add(door);
    }

    public void DestroyDoors()
    {
        foreach(Door door in doors)
        {
                door.DestroyDoor();
        }
    }
}
