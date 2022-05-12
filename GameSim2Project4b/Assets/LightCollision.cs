using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollision : MonoBehaviour
{
    public GameObject spotLightLocalParent;
    public EnemyController1 enemyMainSpotLightParent;
    public GameController gameManager;
    public TransitionController transitionManager;
    public LevelAttributes levelAttributes;
    
    public void PlaceLightCone()
    { 
        Vector3 range = spotLightLocalParent.transform.position;
        range.y = spotLightLocalParent.GetComponent<Light>().range / 2;
        gameObject.GetComponent<Transform>().localScale = new Vector3(range.y, range.y, range.y);
        gameObject.transform.localPosition = new Vector3(0, 0, range.y);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (enemyMainSpotLightParent.enemyState == EnemyController1.EnemyState.Green)
            {
                enemyMainSpotLightParent.enemyState = EnemyController1.EnemyState.Off;
                //enemyMainSpotLightParent.enemyActivated = false;
                levelAttributes.EnemyTriggered();
                if (levelAttributes.CheckIfAllEnemiesForLevel()) 
                {
                    gameManager.transitionLevel = true;
                    transitionManager.start = true;
                }
            }
        }
    }
}
