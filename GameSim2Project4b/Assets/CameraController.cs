using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    public GameObject playerManager;

    public Vector3 cameraOffset;

    public void UpdateCamera()
    {
        // cameraOffset.x = -playerManager.transform.position.x;
        // camera.transform.position = playerManager.transform.position - cameraOffset;
        //
        //
        // camera.transform.eulerAngles = playerManager.GetComponent<PlayerController>().playerRotation;
    }
}
