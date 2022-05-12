using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumController : MonoBehaviour
{
   
    private float _rotationTimerType1;
    private float _timeElapsedType1;
    public int phaseType1;
    public float pendulumPhaseLength;

    private float timeCount = 0.0f;
    
    public void RotatePendulum()
    {
         _rotationTimerType1 = _timeElapsedType1 / pendulumPhaseLength;
         float lerpRotation = Mathf.Lerp(0, 1, _rotationTimerType1);
         _timeElapsedType1 += Time.deltaTime;

        
         switch (phaseType1)
         {
             case 0:
                 transform.rotation = Quaternion.Slerp(Quaternion.Euler(0,0,0), Quaternion.Euler(0,0,55), lerpRotation);
                 break;
             case 1:
                 transform.rotation = Quaternion.Slerp(Quaternion.Euler(0,0,55), Quaternion.Euler(0,0,0), lerpRotation);
                 break;
             case 2:
                 transform.rotation = Quaternion.Slerp(Quaternion.Euler(0,0,0), Quaternion.Euler(0,0,-55), lerpRotation);
                 break;
             case 3:
                 transform.rotation = Quaternion.Slerp(Quaternion.Euler(0,0,-55), Quaternion.Euler(0,0,0), lerpRotation);
                 break;
         }
         if (_rotationTimerType1 >= 1)
         {
             phaseType1++;
             if (phaseType1 >= 4)
             {
                 phaseType1 = 0;
             }
             _timeElapsedType1 = 0;
             
         }
    }
    
}
