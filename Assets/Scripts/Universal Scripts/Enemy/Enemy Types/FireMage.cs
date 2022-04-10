using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMage : Enemy
{
    //These variables describe the chances for thsi enemy to use a special move in percentages. (20 = 20% chance).
    private int pFireShield = 10; //"p"ercentage chance to use the skill "FireShield".
    private int pDebuff = 10;

    //These are the values for the different spells.
    private int fireShieldBlock = 20; //grants 20 block to the lowest enemy.
    private int fireballDamage = 10;
    private int firePillarDamage = 15;
    private int curseOfTheFlameDamage = 6;
    private int iceAndFireDamage = 5;
    private int markTimer = 3;

    private Enemy lowestEnemy;
    private List<Enemy> enemies = new List<Enemy>();

    private Battlesystem battle;

    private int totalDamage;

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(this);
    }

    public override void Intentions()
    {
        SetMove(Random.Range(1,101));

        if(GetBattle() == null) SetBattle(GameObject.FindWithTag("Player").GetComponent<Battlesystem>());
        
        if(Player == null) Player = FindObjectOfType<Player>();

        if(GetMove() <= pFireShield)
        {
            FireShieldIntention();
        }

        else if(GetMove() > pFireShield && GetMove() <= (pFireShield + pDebuff))
        {
            DebuffIntention.enabled = true;
        }
        else
        {
            switch(GetTurnNumber())
            {
                default:
                    Debug.Log("This Turn does not exist.");
                    break;
                
                case 1:
                    FireballIntention();
                    break;

                case 2:
                    FirePillarIntention();
                    break;

                case 3:
                    CurseOfTheFlameIntention();
                    break;

            }
        }
    }

    public override void Move()
    {
        if(GetMove() <= pFireShield)
        {   
            if(lowestEnemy != null)
            FireShield();
        }

        else if(GetMove() > pFireShield && GetMove() <= (pFireShield + pDebuff))
        {
            Player.SetVulnerable(1.5f);
            Player.SetVulnerableTurns(3);
        }

        else
        {
             switch(GetTurnNumber())
            {
                case 1:
                Fireball();
                SetTurnNumber(2);
                break;

                case 2:
                FirePillars();
                SetTurnNumber(3);
                break;

                case 3:
                CurseOfTheFlame();
                SetTurnNumber(1);
                break;
            }
        }

        if(Player.GetMarkOfFlame() == 1 && Player.GetMarkOfIce() == 1)
        {
            CalculateDamage(iceAndFireDamage);
            Player.SetMarkOfFlame(0);
            Player.SetMarkOfIce(0);
            Player.SetIceTurns(0);
            Player.SetFlameTurns(0);
        } 
    
        IntentionText.text = "";
        IntentionText.color = Color.red;
        AttackIntention.enabled = false;
        FixDamageIntention.enabled = false;
        DebuffIntention.enabled = false;
        BuffIntention.enabled = false;

        DealDamage();
    }

    //Throws a fireball on the tile the Player stood on in the beginning of the Turn.
    public void Fireball()
    {
        if(Player.transform.position.x == GetBattle().startTurnPos.x)
        {
            CalculateDamage(fireballDamage);
            Player.SetFlameTurns(markTimer);
            Player.SetMarkOfFlame(1);
        }
    }

    public void FireballIntention()
    {
        switch(GetBattle().startTurnPos.x)
        {
            default:
                Debug.Log("This is not a viable Position for the Player.");
                break;

            case -2:
                GetBattle().MarkFloor(true, false, false, false ,false);
                break;
            
            case -1:
                GetBattle().MarkFloor(false, true, false, false ,false);
                break;

            case 0:
                GetBattle().MarkFloor(false, false, true, false ,false);
                break;

            case 1:
                GetBattle().MarkFloor(false, false, false, true ,false);
                break;

            case 2:
                GetBattle().MarkFloor(false, false, false, false ,true);
                break;     
        }

        IntentionText.text = Mathf.RoundToInt(Player.GetVulnerable()*fireballDamage).ToString();
        AttackIntention.enabled = true;
    }

    //Shoots firepillars out uf every odd Tile
    public void FirePillars()
    {
        if(Player.transform.position.x % 2 == 0)
        {
            CalculateDamage(firePillarDamage);
            Player.SetFlameTurns(markTimer);
            Player.SetMarkOfFlame(1);
        }
    }

    public void FirePillarIntention()
    {
        GetBattle().MarkFloor(true, false, true, false, true);
        IntentionText.text =  Mathf.RoundToInt(Player.GetVulnerable()*firePillarDamage).ToString();
        AttackIntention.enabled = true;
    }

    public void CurseOfTheFlame()
    {
        CalculateDamage(curseOfTheFlameDamage);
        Player.SetFlameTurns(markTimer);
        Player.SetMarkOfFlame(1);
    }

    public void CurseOfTheFlameIntention()
    {
        IntentionText.text = Mathf.RoundToInt(Player.GetVulnerable()*curseOfTheFlameDamage).ToString();
        IntentionText.color = Color.magenta;
        FixDamageIntention.enabled = true;
    }

    public void FireShield()
    {
        lowestEnemy.IncBlock(fireShieldBlock);
    }

    public void FireShieldIntention()
    {
        enemies = GetBattle().GetEnemies();
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

        IntentionText.color = Color.blue;
        IntentionText.text = fireShieldBlock.ToString();
        BuffIntention.enabled = true;
    }

    public void CalculateDamage(int damage)
    {
        totalDamage += damage;
    }

    public void DealDamage()
    {
        GetBattle().DealDamageToPlayer(Player, totalDamage);
        totalDamage = 0;
    }
}
