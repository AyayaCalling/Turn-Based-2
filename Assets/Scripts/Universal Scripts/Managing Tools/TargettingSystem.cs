using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class manages the targetting of different enemies.
public class TargettingSystem : MonoBehaviour
{
    public Enemy target;

    //This is an array of all present enemies. (Might be unnecessary. Currently under investigation)
    private Enemy[] enemies;

    //Calls "UpdateArray" when loading a new scene.
    public void Start()
    {
        UpdateArray();
    }

    //This methods searchs for enemies in the scene and adds them to "enemies".
    public void UpdateArray()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    //Sets the given enemy to be the active target.
    public void TargetThisEnemy(Enemy thisEnemy)
    {
        target = thisEnemy;
        Debug.Log("Now Targetting:" + thisEnemy);
    }

}
