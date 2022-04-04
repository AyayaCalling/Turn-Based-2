using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject thisObj;


    public void Awake()
    {
        DontDestroyOnLoad(thisObj);
    }

    public void DestroyHUD()
    {
        Destroy(thisObj);
    }
}
