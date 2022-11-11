using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descriptions : MonoBehaviour
{
    public Player Player;

    public GameObject DescriptionBackground;
    public Text DescriptionText;
    public Text Headline;

    public virtual void Awake()
    {
        Player = FindObjectOfType<Player>();
    }

    public virtual void ChangeText(string changeTo)
    {   
        
    }

    public virtual void UpdateDescription(int iD)
    {

    }

    public virtual void OnMouseOver()
    {
        DescriptionBackground.SetActive(true);
    }

    public virtual void OnMouseExit()
    {
        DescriptionBackground.SetActive(false);
    }
}
