using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int currentLevel;
    
    public PlayerController playerManager;

    public EnemyController enemyManager;

    public TransitionController transitionManager;
    public bool transitionLevel;
    //public CameraController cameraManager;
    
    
    void Update()
    {
        // PlayerController
        playerManager.UpdatePlayer();
        
        // EnemyController
        enemyManager.ControlEnemyPerLevel(currentLevel);

            //        Debug.Log(transitionLevel);
        if (transitionLevel)
        {
            transitionManager.TransitionLevel(currentLevel);
        }
        
        // CameraController
        // cameraManager.UpdateCamera();
    }
}
