using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject thisObj;

    private List<Door> doors = new List<Door>();

    public void Awake()
    {
        DontDestroyOnLoad(thisObj);
    }

    public void DestroyHUD()
    {
        Destroy(thisObj);
    }

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
