using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerLight;
    public PlayerLightController playerSpotLightCone;
    public GameObject player;
    public float playerWalkingSpeed;
    
    public float speedHorizontal;
    public float speedVertical;

    private float _yaw;
    private float _pitch;

    public Vector3 playerRotation;
    
    public enum PlayerState
    {
        Walking,
        Running,
        Idle
    }
    
    public PlayerState playerState;

    private void PlayerWalking()
    {
        CharacterController playerMove = this.GetComponent<CharacterController>();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);
        direction.y = SetToGround();
        playerMove.Move(direction * Time.deltaTime * playerWalkingSpeed);
    }
    
    // private void InputsFsmFunction()
    // {
    //     switch (playerState)
    //     {
    //         case PlayerState.Idle:
    //         {
    //             if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
    //             {
    //                 playerState = PlayerState.Walking;
    //             }
    //         } break;
    //         
    //         case PlayerState.Walking:
    //         {
    //             if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
    //             {
    //                 playerState = PlayerState.Idle;
    //             }
    //         } break;
    //     } 
    // }

    float SetToGround()
    {
        float groundDistance = 0;
        Ray rayDown = new Ray();
        rayDown.origin = gameObject.transform.position;
        rayDown.direction = Vector3.down;
        
        RaycastHit info;
        
        if (Physics.Raycast(rayDown, out info))
        {
            if (info.distance >= 1.11f)
            {
                groundDistance = 1.11f - info.distance;
            }
            else
            {
                groundDistance = 0;
            }
        }

        return groundDistance;
    }
    public void MovePlayer()
    {

        switch (playerState)
        {
            case PlayerState.Idle:
            {
                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    playerState = PlayerState.Walking;
                }
            } break;
            
            case PlayerState.Walking:
            {
                PlayerWalking();
            } break;
        }

        SetToGround();
    }

    public void RotatePlayer()
    {
        // Camera Rotation
        _yaw += speedHorizontal * Input.GetAxis("Mouse X") * Time.deltaTime;
        _pitch -= speedVertical * Input.GetAxis("Mouse Y") * Time.deltaTime;
        
        playerRotation = new Vector3(_pitch, _yaw, 0.0f);
        
        if (playerRotation.x > 35)
        {
            playerRotation.x = 35;
            _pitch = playerRotation.x;
        }
        if (playerRotation.x < -35)
        {
            playerRotation.x = -35;
            _pitch = playerRotation.x;
        }
        
        transform.eulerAngles = playerRotation;
        
    }

    public void TurnOnPlayerLight()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerLight.activeSelf == true)
            {
                playerLight.SetActive(false);
            }
            else
            {
                playerLight.SetActive(true);
                playerSpotLightCone.GetComponent<PlayerLightController>().PlacePlayerLightCone();
            }
        }
    }
    
    // PUBLIC - MovePlayer called in GameController.cs
    public void UpdatePlayer()
    {
        //InputsFsmFunction();
        MovePlayer();
        RotatePlayer();
        TurnOnPlayerLight();
    }

    private void Start()
    {
        playerState = PlayerState.Idle;
    }
}
