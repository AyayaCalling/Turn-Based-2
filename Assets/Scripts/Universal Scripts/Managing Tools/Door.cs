using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   public HUD HUD;

   public void Awake()
   {
       HUD.UpdateDoorList(this.GetComponent<GameObject>());
   }
}
