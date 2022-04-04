using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject thisObj;

    private List<GameObject> doors = new List<GameObject>();

    public void Awake()
    {
        DontDestroyOnLoad(thisObj);
    }

    public void DestroyHUD()
    {
        Destroy(thisObj);
    }

    public void UpdateDoorList(GameObject door)
    {  
        doors.Add(door);
    }

    public void DestroyDoors()
    {
        foreach(GameObject door in doors)
        {
            if(door.transform.position.y != -400)
            {
                Destroy(door.GetComponent<GameObject>());
            }
        }
    }
}
