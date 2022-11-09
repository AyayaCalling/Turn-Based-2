using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public Player player;

    private int vigor;
    private int mind;
    private int dexterity;
    private int strength;
    private int intelligence;

    // ÄNDERUNG VON SET METHODEN AUF INC/DEC to be implemented
    private void Awake()
    {
        vigor = player.GetVigor();
        mind = player.GetMind();
        dexterity = player.GetDexterity();
        strength = player.GetStrength();
        intelligence = player.GetIntelligence();

        player.SetMaxHP(50 + vigor);
        player.SetCurrentHP(player.GetMaxHP());
        player.SetMaxMana(100 + mind);
        player.SetCurrentMana(player.GetMaxMana());
        player.SetPhysDamage(5 + strength);
        player.SetMagicDamage(5 + intelligence);
    }

}
