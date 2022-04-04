using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class constantly checks, if the Player has ressources to use skills and locks them otherwise.
public class ManaObserver : MonoBehaviour
{
    #region Variables

    //This variable stores all needed player info.
    public Player Player;

    //These variables are used to dis-/enable the skills buttons.
    public Button SkillOneButton;
    public Button SkillTwoButton;
    public Button SkillThreeButton;

    //These variables store all needed skill info.
    public Skill SkillOne;
    public Skill SkillTwo;
    public Skill SkillThree;

    #endregion

    //This method locks skills, if they cost more mana, than the player currently has.
    public void ManaValueChange()
    {
        if(Player.GetCurrentMana() < SkillOne.GetManaCost()) SkillOneButton.interactable = false;
        if(Player.GetCurrentMana() < SkillTwo.GetManaCost()) SkillTwoButton.interactable = false;
        if(Player.GetCurrentMana() < SkillThree.GetManaCost()) SkillThreeButton.interactable = false;
    }
}