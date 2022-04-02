using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class manages the targetting of different enemies.
public class TargettingSystem : MonoBehaviour
{
    public Enemy target;

    private Enemy[] enemies;

    public void Start()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    public void TargetThisEnemy(Enemy thisEnemy)
    {
        target = thisEnemy;
        Debug.Log("Now Targetting:" + thisEnemy);
    }

}
