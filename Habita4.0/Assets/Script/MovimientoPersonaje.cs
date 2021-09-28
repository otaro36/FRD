using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    //public Rigidbody moveRB;
    [Range(0, 10)] public float speed;
    private Vector3 playerInput;
    public float horizontal;
    public float vertical;
    public CharacterController player;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    public float gravity;
    public float fallVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        playerInput = new Vector3(horizontal, 0, vertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        CamDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * speed;
        player.transform.LookAt(player.transform.position + movePlayer);
        SetGravity();
        player.Move(movePlayer* Time.deltaTime);
    }

    void SetGravity()
    {
        
        if (player.isGrounded)
        {
            fallVelocity = -gravity*Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity*Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
