using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is used to manage the character selection in the main menu (Only cosmetic so far!).
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
