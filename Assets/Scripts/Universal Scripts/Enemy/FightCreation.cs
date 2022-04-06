using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class randomly generates one of several different fight Layouts.
public class FightCreation : MonoBehaviour
{
    public Player Player;

    //These variables are used to choose a specific Layout, out of all possible Layouts.
    private int fightCode;

    private int numberOfPossibleFights = 2;
    /*List of Possible Fights by Fight-Code:
    1. 1 "NAMEONE"
    2. 2 "NAMEONE"s
    3. 1 "NAMEONE" 1 "NAMETWO"
    4. 3 "NAMETHREE"s
    5. ...
    6. ...
    */

    //These are all enemies that can occur in a fight. (NAMES TBD)
    public Enemy EnemyOneName;
    public Enemy EnemyTwoName;
    public Enemy EnemyThreeName;

    //These are all Vectors that enemies can be placed on.
    private Vector3 posOne = new Vector3(-1, 0, 10);
    private Vector3 posTwo = new Vector3(-2, 0, 10);
    private Vector3 posThree = new Vector3(-5, 0, 10);
    private Vector3 posFour = new Vector3(1, 0, 10);
    private Vector3 posFive = new Vector3(4, 0, 10);

    private Quaternion standard = new Quaternion(0, 0, 0, 0);

    //This method randomizes the Fight layout and instanciates all enemies.
    public void CreateFight()
    {
        fightCode = Random.Range(1,(numberOfPossibleFights + 1));

        switch(fightCode)
        {
            default: 
                Debug.Log("This Fight-Code does not exist!");
                break;

            case 1:
                Instantiate(EnemyOneName, posOne, standard, Player.PlayerObj.transform);
                break;

            case 2:
                Instantiate(EnemyOneName, posTwo, standard, Player.PlayerObj.transform);
                Instantiate(EnemyOneName, posFour, standard, Player.PlayerObj.transform);
                break;

        }
    }

    public void CreateBossFight()
    {
        Debug.Log("Bossfight initiated.");
        Instantiate(EnemyOneName, posOne, standard, Player.PlayerObj.transform);
        Instantiate(EnemyOneName, posTwo, standard, Player.PlayerObj.transform);
        Instantiate(EnemyOneName, posThree, standard, Player.PlayerObj.transform);
        Instantiate(EnemyOneName, posFour, standard, Player.PlayerObj.transform);
        Instantiate(EnemyOneName, posFive, standard, Player.PlayerObj.transform);
                
    }
}
