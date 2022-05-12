using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
   public float enemySpeed;
   public float quaternionTimer;
   private Vector3 rotationTotal;
   public float rotationSpeedValue;
   public bool runRayChecker;
   public bool DetectObstruction()
   {
      bool obstructionPresent = false;
      Ray rayObjectForward = new Ray();
      rayObjectForward.origin = transform.position;
      rayObjectForward.direction = transform.forward;
      
      //Debug.DrawRay(rayForward.origin, rayForward.direction, Color.green);

      RaycastHit info;
      if (Physics.Raycast(rayObjectForward, out info))
      {
         //Debug.Log(info.distance);
         if (info.distance < 1f)
         {
            if (info.collider.tag == "EnemyHinge" || info.collider.tag == "Edge")
            {
               obstructionPresent = true;
            }
         }
      }
      
      return obstructionPresent;
   }
   public void MoveEnemy()
   {
      Vector3 moveEnemy = transform.forward * enemySpeed * Time.deltaTime;

      if (DetectObstruction())
         {
            // quaternionTimer += Time.deltaTime * 100 ;
            //Quaternion quaternion = Quaternion.Euler(0, Time.deltaTime, 0);
            Vector3 displacementRotation = Vector3.zero;
            
            displacementRotation.y += Random.Range(45, 80);
            int randomNeg = Random.Range(0, 2);
            if (randomNeg == 0)
            {
               transform.eulerAngles += displacementRotation;
            }
            else
            {
               transform.eulerAngles -= displacementRotation;
            }
            
            
            //transform.eulerAngles = Quaternion.Euler(0, quaternionTimer, 0);
         }
         else
         {
            transform.position += moveEnemy;
         }
      
      
   }
}
