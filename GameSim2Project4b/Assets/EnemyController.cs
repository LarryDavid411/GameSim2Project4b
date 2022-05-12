using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] enemyObjectsType1;
    public GameObject[] enemyObjectsType2;
    
    private void Start()
    {
        enemyObjectsType1 = GameObject.FindGameObjectsWithTag("Enemy1");
        //enemyObjectsType1 = GameObject.FindGameObjectsWithTag("Enemy2");
    }

    public void ControlEnemyPerLevel(int currentLevel)
    {
        // for (int i = 0; i < enemyObjectsType2.Length; i++)
        // {
        //     EnemyController2 levelEnemyType2 = enemyObjectsType2[i].GetComponent<EnemyController2>();
        //     if (levelEnemyType2.levelForEnemy == currentLevel)
        //     {
        //         levelEnemyType2.UpdateEnemy();
        //     }
        //
        //     if (levelEnemyType2.levelForEnemy == currentLevel - 1)
        //     {
        //         levelEnemyType2.UpdateEnemy();
        //     }
        //     
        // }
        
        for (int i = 0; i < enemyObjectsType1.Length; i++)
        {
            // Control Current Level Enemies
            EnemyController1 levelEnemyType1 = enemyObjectsType1[i].GetComponent<EnemyController1>();
            if (levelEnemyType1.levelForEnemy == currentLevel)
            {
                levelEnemyType1.UpdateEnemy();
            }
            
            // Control Previous Level Enemies
            if (levelEnemyType1.levelForEnemy == currentLevel - 1)
            {
                levelEnemyType1.UpdateEnemy();
            }
        }
    }
}
