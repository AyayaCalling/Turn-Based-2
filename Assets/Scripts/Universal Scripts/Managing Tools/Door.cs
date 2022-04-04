using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class currently only exists to destroy doors after exiting a room (weird work around).
public class Door : MonoBehaviour
{
   public HUD HUD;

   public GameObject thisDoor;

   public void Awake()
   {
       HUD.UpdateDoorList(this);
   }

   public void DestroyDoor()
   {
       if(thisDoor.name.Contains("Clone"))
       {
            Debug.Log("Destroying door: " + thisDoor);
            Destroy(thisDoor);
       }
   }
}
