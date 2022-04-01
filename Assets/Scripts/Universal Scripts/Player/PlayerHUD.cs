using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Slider Healthbar;
    public Slider ManaBar;

    public Text HealthText;
    public Text ManaText;
    public Text BlockText;

    public Button SkillOne;
    public Button SkillTwo;
    public Button SkillThree;

    public Player player;

    private void Start()
    {
        updateSliders();
    }

    private void Update()
    {
        Healthbar.value = player.GetCurrentHP();
        ManaBar.value = player.GetCurrentMana();
        HealthText.text = player.GetCurrentHP().ToString() + "/" + player.GetMaxHP().ToString();
        ManaText.text = player.GetCurrentMana().ToString() + "/" + player.GetMaxMana().ToString();
        BlockText.text = player.GetBlock().ToString();
      
    }

    public void updateSliders()
    {
        Healthbar.maxValue = player.GetMaxHP();
        ManaBar.maxValue = player.GetMaxMana();
    }

  
}
