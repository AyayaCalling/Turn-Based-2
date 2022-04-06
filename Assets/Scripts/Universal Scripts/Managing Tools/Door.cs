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
       AddToHUD();
   }

   public void DestroyDoor()
   {
       if(thisDoor.name.Contains("Clone"))
       {
            Destroy(thisDoor);
       }
   }

   public void AddToHUD()
   {
       HUD.AddDoor(this);
   }
}
