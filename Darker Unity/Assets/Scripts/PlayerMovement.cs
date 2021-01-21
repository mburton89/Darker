﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference to the character controller
    public CharacterController controllerPlayer;

    //Values for movement speeds and other world constants
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    //Variables for ground checks
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    //Crouching variables
    bool isCrouched;
    public Transform playerCamera;

    // Update is called once per frame
    void Update()
    {
        //Checks for falling and if the play is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        //Recieves input from player using WASD keys for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Moves the player along the ground
        Vector3 move = transform.right * x + transform.forward * z;
        controllerPlayer.Move(move * speed * Time.deltaTime);

        //Checks for input and changes the player into or out of a crouched position
        if (Input.GetKeyDown(KeyCode.C) && !isCrouched)
        {
            speed = 6f;
            playerCamera.position += new Vector3(0f, -1f, 0f);
            isCrouched = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCrouched)
        {
            speed = 12f;
            playerCamera.position += new Vector3(0f, 1f, 0f);
            isCrouched = false;
        }

        //Checks if the player is attempting to jump while grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Moves the player using gravity variables when falling
        velocity.y += gravity * Time.deltaTime;
        controllerPlayer.Move(velocity * Time.deltaTime);
    }
}
