using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostMage : Enemy
{
    //These variables describe the chances for thsi enemy to use a special move in percentages. (20 = 20% chance).
    private int pFrozenMedicine = 10; //"p"ercentage chance to use the skill "FrozenMedicine".
    private int pDebuff = 10;

    //These are the values for the different spells.
    private int FrozenMedicineHeal = 20; //grants 20 block to the lowest enemy.
    private int IceBallDamage = 10;
    private int FrostPillarDamage = 15;
    private int CurseOfTheColdDamage = 5;

    private Enemy lowestEnemy;
    private List<Enemy> enemies = new List<Enemy>();

    private Battlesystem battle;

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(this);
    }

    public override void Intentions()
    {
        SetMove(Random.Range(1,101));

        Debug.Log(GetMove());

        if(GetBattle() == null) SetBattle(GameObject.FindWithTag("Player").GetComponent<Battlesystem>());
        
        if(Player == null) Player = FindObjectOfType<Player>();

        if(GetMove() <= pFrozenMedicine)
        {
            FrozenMedicineIntention();
        }

        else if(GetMove() > pFrozenMedicine && GetMove() <= (pFrozenMedicine + pDebuff))
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
                    IceballIntention();
                    break;

                case 2:
                    FrostPillarIntention();
                    break;

                case 3:
                    CurseOfTheColdIntention();
                    break;

            }
        }
    }

    public override void Move()
    {
        if(GetMove() <= pFrozenMedicine)
        {   
            if(lowestEnemy != null)
            FrozenMedicine();
        }

        else if(GetMove() > pFrozenMedicine && GetMove() <= (pFrozenMedicine + pDebuff))
        {
            Player.SetVulnerable(5);
            Player.SetVulnerableTurns(3);
        }

        else
        {
             switch(GetTurnNumber())
            {
                case 1:
                Iceball();
                SetTurnNumber(2);
                break;

                case 2:
                FrostPillars();
                SetTurnNumber(3);
                break;

                case 3:
                CurseOfTheCold();
                SetTurnNumber(1);
                break;
            }
        }

        IntentionText.text = "";
        IntentionText.color = Color.red;
        AttackIntention.enabled = false;
        FixDamageIntention.enabled = false;
        DebuffIntention.enabled = false;
        BuffIntention.enabled = false;
    }

    //Throws an iceball on the tile the Player stood on in the beginning of the Turn.
    public void Iceball()
    {
        if(Player.transform.position.x == GetBattle().startTurnPos.x)
        {
            GetBattle().DealDamageToPlayer(Player, IceBallDamage);
        }
    }

    public void IceballIntention()
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

        IntentionText.text = Mathf.RoundToInt(Player.GetVulnerable()*IceBallDamage).ToString();
        AttackIntention.enabled = true;
    }

    //Shoots frostpillars out uf every odd Tile
    public void FrostPillars()
    {
        if(Player.transform.position.x == 1 || Player.transform.position.x == -1)
        {
            GetBattle().DealDamageToPlayer(Player, FrostPillarDamage);
        }
    }

    public void FrostPillarIntention()
    {
        GetBattle().MarkFloor(false, true, false, true, false);
        IntentionText.text =  Mathf.RoundToInt(Player.GetVulnerable()*FrostPillarDamage).ToString();
        AttackIntention.enabled = true;
    }

    public void CurseOfTheCold()
    {
        GetBattle().DealDamageToPlayer(Player, CurseOfTheColdDamage);
    }

    public void CurseOfTheColdIntention()
    {
        IntentionText.text = Mathf.RoundToInt(Player.GetVulnerable()*CurseOfTheColdDamage).ToString();
        IntentionText.color = Color.magenta;
        FixDamageIntention.enabled = true;
    }

    public void FrozenMedicine()
    {
        lowestEnemy.IncCurrentHP(FrozenMedicineHeal);
    }

    public void FrozenMedicineIntention()
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
        IntentionText.text = FrozenMedicineHeal.ToString();
        BuffIntention.enabled = true;
    }
}
