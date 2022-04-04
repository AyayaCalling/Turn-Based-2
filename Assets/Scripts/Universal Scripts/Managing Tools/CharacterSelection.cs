using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button SelectKnight;

    public SceneHandler scenes;

    public void Update()
    {
        switch(scenes.GetCharacter())
        {
            case null:
                SelectKnight.GetComponent<Image>().color = Color.red;
                Debug.Log("No Character selected.");
            break;

            case "Knight":
                SelectKnight.GetComponent<Image>().color = Color.green;
                Debug.Log("Knight selected.");
            break;
        }
    }
    
}
