using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLightTrigger : MonoBehaviour
{
   public float upSpeed;
   public LevelAttributes levelAttributes;
   public GameController gameManager;
   public TransitionController transitionManager;
   public bool willAddTrigger;

   public void MoveLightTrigger()
   {
      gameObject.transform.position += Vector3.up * Time.deltaTime * upSpeed;
      
      if (transform.position.y > 0.75)
      {
         Vector3 setPosition = transform.localPosition;
         setPosition.y = 0.75f;
         transform.localPosition = setPosition;
         if (!willAddTrigger)
         {
            levelAttributes.EnemyTriggered();
            willAddTrigger = true;
            if (levelAttributes.CheckIfAllEnemiesForLevel()) 
            {
               gameManager.transitionLevel = true;
               transitionManager.start = true;
            }
         }
         
      }
   }
}
