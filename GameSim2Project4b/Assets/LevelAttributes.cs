using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAttributes : MonoBehaviour
{
   public int numberOfEnemiesInLevel;
   public int numberOfEnemiesTriggered;
 
   public void EnemyTriggered()
   {
      numberOfEnemiesTriggered++;
   }

   public bool CheckIfAllEnemiesForLevel()
   {
      bool advanceLevel = false;
      if (numberOfEnemiesTriggered == numberOfEnemiesInLevel)
      {
         advanceLevel = true;
      }

      return advanceLevel;
   }

}
