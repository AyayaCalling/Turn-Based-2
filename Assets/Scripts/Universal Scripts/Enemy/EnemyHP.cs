using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider HPSlider;
    public Enemy Enemy;

    public Text HealthText;

    public void Awake()
    {
        HPSlider.maxValue = Enemy.GetMaxHP();
        HPSlider.value = Enemy.GetMaxHP();
    }

    private void Update()
    {
        HPSlider.value = Enemy.GetCurrentHP();       
        HealthText.text = Enemy.GetCurrentHP().ToString() + "/" + Enemy.GetMaxHP().ToString();  
    }
}
