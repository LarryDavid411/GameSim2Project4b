using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFlicker : MonoBehaviour
{
    public float minFlickerTimeOff;
    public float maxFlickerTimeOff;
    public float minFlickerTimeOn;
    public float maxFlickerTimeOn;
    public float _timerOff;
    public float _timerOn;
    private bool _lightSwitch;
    public void FlickMenu()
    {
        if (_lightSwitch)
        {
            this.gameObject.SetActive(_lightSwitch);
            _timerOff += Time.deltaTime;
            if (_timerOff >= Random.Range(minFlickerTimeOn, maxFlickerTimeOn))
            {
                _lightSwitch = false;
            
                _timerOff = 0;
            }
        }

        if (!_lightSwitch)
        {
            this.gameObject.SetActive(_lightSwitch);
            _timerOn += Time.deltaTime;
            if (_timerOn >= Random.Range(minFlickerTimeOff, maxFlickerTimeOff))
            {
                _lightSwitch = true;
                _timerOn = 0;
            }
        }
    }
}
