using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
   //public Transform playerLightCone;
   public GameObject spotlightLocalParent;
   public HitLightTrigger triggerObject;
      
   public void PlacePlayerLightCone()
   {
      Vector3 range = spotlightLocalParent.transform.localScale;
      range.z = spotlightLocalParent.GetComponent<Light>().range / 2;
      //gameObject.GetComponent<Transform>().t = range;
      Vector3 angle = new Vector3();
      angle.z = spotlightLocalParent.GetComponent<Light>().spotAngle;
      //gameObject.GetComponent<Transform>().localScale = new Vector3(range.y, range.y, range.y);
      this.gameObject.transform.localScale = new Vector3(angle.z, angle.z, range.z);
      gameObject.transform.localPosition = new Vector3(0, 0, range.z);
     // Debug.Log(range);
   }

   private void OnTriggerStay(Collider other)
   {
      if (other.tag == "PlayerLightCone")
      {
         triggerObject.MoveLightTrigger();
      }
   }
}
