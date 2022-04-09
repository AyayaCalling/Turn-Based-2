using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMage : Enemy
{
    //These variables describe the chances for thsi enemy to use a special move in percentages. (20 = 20% chance).
    private int pFireShield = 20; //"p"ercentage chance to use the skill "FireShield".
    private int pDebuff = 30;

    //These are the values for the different spells.
    private int FireShield = 20; //grants 20 block to the lowest enemy.

    private Enemy lowestEnemy;
    private List<Enemy> enemies = new List<Enemy>();

    private Battlesystem battle;

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(this);
    }

    public override void Intentions()
    {
        if(battle == null) battle = GameObject.FindWithTag("Player").GetComponent<Battlesystem>();
        if(GetMove() <= pFireShield)
        {
            enemies = battle.GetEnemies();
            foreach(Enemy enemy in enemies)
            {
                if(lowestEnemy != null && enemy.GetCurrentHP() < lowestEnemy.GetCurrentHP())
                {
                    lowestEnemy = enemy;
                }
                else if(lowestEnemy == null)
                {
                    lowestEnemy = enemy;
                }
            }

            Debug.Log(this + " will shield " + lowestEnemy + " for " + FireShield);
        }

        else if(GetMove() > pFireShield && GetMove() <= (pFireShield + pDebuff))
        {
            Debug.Log(this + " will aplly 3 Turns of vulnerable.");
        }
        else
        {
            base.Intentions();
        }
    }

    public override void Move()
    {
        if(GetMove() <= pFireShield)
        {   
            if(lowestEnemy != null)
            lowestEnemy.IncBlock(FireShield);
        }

        else if(GetMove() > pFireShield && GetMove() <= (pFireShield + pDebuff))
        {
            Player.SetVulnerable(5);
            Player.SetVulnerableTurns(3);
        }

        else
        {
            base.Move();
        }
    }


}
