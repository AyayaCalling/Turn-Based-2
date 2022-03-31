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

    private void Awake()
    {
        vigor = player.GetVigor();
        mind = player.GetMind();
        dexterity = player.GetDexterity();
        strength = player.GetStrength();
        intelligence = player.GetIntelligence();

        player.SetMaxHP(50 + vigor);
        player.SetCurrentHP(player.GetMaxtHP());
        player.SetMaxMana(3 + mind);
        player.SetCurrentMana(player.GetMaxtMana());
        player.SetPhysDamage(5 + strength);
        player.SetMagicDamage(5 + intelligence);
    }

    private void Update()
    {
        vigor = player.GetVigor();
        mind = player.GetMind();
        dexterity = player.GetDexterity();
        strength = player.GetStrength();
        intelligence = player.GetIntelligence();

        player.SetMaxHP(50 + vigor);
        player.SetMaxMana(3 + mind);
        player.SetPhysDamage(5 + strength);
        player.SetMagicDamage(5 + intelligence);

    }
}
