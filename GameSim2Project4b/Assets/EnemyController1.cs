using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyController1 : MonoBehaviour
{
   public int levelForEnemy;
   
   public bool enemyActivated;
   public GameController gameManager;
   public TransitionController transitionManager;
   
   public GameObject spotLight;
   public Material spotLightMaterial;
   private float _stateTimer;
   public float redStateInterval;
   private float _transitionTimer;
   public float stateChangeLength;
   public float greenStateInterval;
   private Light _light;
   public int type;
   public Transform targetType1;

   public LightCollision lightCollision;


   public PendulumController pendulum;
   public MovementController movement;
   private float _rotationTimerType1;
   private float _timeElapsedType1;
   public int phaseType1;
   public float rotationSpeedType1;
   public float rotationDurationType1;
   public int direction;
   
   
   private void Start()
   {
      _light = spotLight.GetComponent<Light>();
   }

   public enum EnemyState
   {
      Red,
      Green,
      TransitionToGreen,
      TransitionToRed,
      Off
   }

   public EnemyState enemyState;
   public void ChangeLighting()
   {
      switch (enemyState)
      {
         case EnemyState.Red:
         {
//            _light.enabled = true;
            _stateTimer += Time.deltaTime;
            if (_stateTimer > redStateInterval)
            {
               _stateTimer = 0;
               enemyState = EnemyState.TransitionToGreen;
            }
         } break;
         case EnemyState.Green:
         {
            //    _light.enabled = true;
            _stateTimer += Time.deltaTime;
            if (_stateTimer > greenStateInterval)
            {
               _stateTimer = 0;
               enemyState = EnemyState.TransitionToRed;
            }
         } break;
         case EnemyState.TransitionToRed:
         {
           // _light.enabled = true;
            _transitionTimer += Time.deltaTime;
            spotLight.GetComponent<Light>().color = Color.Lerp(Color.green, Color.red, _transitionTimer / stateChangeLength);
            spotLightMaterial.SetColor("_EmissionColor",spotLight.GetComponent<Light>().color);
            if (_transitionTimer / stateChangeLength > 1)
            {
               _transitionTimer = 0;
               enemyState = EnemyState.Red;
            }
         } break;
         case EnemyState.TransitionToGreen:
         {
           // _light.enabled = true;
            _transitionTimer += Time.deltaTime;
            spotLight.GetComponent<Light>().color = Color.Lerp(Color.red, Color.green, _transitionTimer / stateChangeLength);
            spotLightMaterial.SetColor("_EmissionColor",spotLight.GetComponent<Light>().color);
            if (_transitionTimer / stateChangeLength > 1)
            {
               _transitionTimer = 0;
               enemyState = EnemyState.Green;
            }
         } break;
         case EnemyState.Off:
         { 
            spotLight.GetComponent<Light>().color = Color.white;
            spotLightMaterial.SetColor("_EmissionColor",spotLight.GetComponent<Light>().color);
            enemyActivated = false;
         } break;
      }

      if (type == 2)
      {
         pendulum.RotatePendulum();
      }

      if (type == 3)
      {
         movement.MoveEnemy();
      }
   }

   public void UpdateEnemy()
   {
      if (enemyActivated)
      {
         ChangeLighting();
         lightCollision.PlaceLightCone();
      }
   }
}
