using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaObserver : MonoBehaviour
{
    #region Variables

    public Player Player;

    public Button SkillOneButton;
    public Button SkillTwoButton;
    public Button SkillThreeButton;

    public Skill SkillOne;
    public Skill SkillTwo;
    public Skill SkillThree;

    #endregion

    public void ManaValueChange()
    {
        if(Player.GetCurrentMana() < SkillOne.GetManaCost()) SkillOneButton.interactable = false;
        if(Player.GetCurrentMana() < SkillTwo.GetManaCost()) SkillTwoButton.interactable = false;
        if(Player.GetCurrentMana() < SkillThree.GetManaCost()) SkillThreeButton.interactable = false;
    }
}