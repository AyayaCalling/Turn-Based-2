using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is a Hud specifically for the player and his information.
public class PlayerHUD : MonoBehaviour
{
    #region Variables

    //Sliders for mana and health.
    public Slider Healthbar;
    public Slider ManaBar;

    //Texts displaying the current value of Health, Mana and Block
    public Text HealthText;
    public Text ManaText;
    public Text BlockText;

    //Buttons for each Skill.
    public Button SkillOne;
    public Button SkillTwo;
    public Button SkillThree;

    //As always (stores important player info)
    public Player player;

    #endregion

    //Initial Slider Update.
    private void Start()
    {
        updateSliders();
    }

    //Permanently tracks all values to correctly display them to the user. Might not be needed every frame (only on change?)!
    private void Update()
    {
        Healthbar.value = player.GetCurrentHP();
        ManaBar.value = player.GetCurrentMana();
        HealthText.text = player.GetCurrentHP().ToString() + "/" + player.GetMaxHP().ToString();
        ManaText.text = player.GetCurrentMana().ToString() + "/" + player.GetMaxMana().ToString();
        BlockText.text = "+" + player.GetBlock().ToString();
      
    }

    //This method Updates the Sliders max capacity, if the regarded values change.
    public void updateSliders()
    {
        Healthbar.maxValue = player.GetMaxHP();
        ManaBar.maxValue = player.GetMaxMana();
    }  
}
