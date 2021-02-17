using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Reference to the character controller
    public CharacterController controllerPlayer;

    //Values for movement speeds and other world constants
    public float speed = 10f;
    public float gravity = -9.8f;
    public float jumpHeight = 6f;

    //Variables for ground checks
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    //Crouching variables
    bool isCrouched;
    public Transform playerCamera;
    public int frameStep = 0;

    public bool isSprint = false;

    // Update is called once per frame
    void Update()
    {
        //Checks for falling and if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
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
            //Crouch();
            frameStep++;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCrouched)
        {
            //Uncrouch();
            frameStep--;
        }
        if (!isCrouched && frameStep > 0)
        {
            switch (frameStep)
            {
                case 2:
                    controllerPlayer.height -= 0.5f;
                    speed -= 1.5f;
                    break;
                case 4:
                    controllerPlayer.height -= 0.5f;
                    speed -= 1.5f;
                    break;
                case 6:
                    controllerPlayer.height -= 0.5f;
                    speed -= 1.5f;
                    break;
                case 8:
                    controllerPlayer.height = 1.8f;
                    speed = 4f;
                    isCrouched = true;
                    frameStep--;
                    break;
                default:
                    break;

            }
            frameStep++;
        }
        if (isCrouched && frameStep < 8)
        {
            switch (frameStep)
            {
                case 6:
                    controllerPlayer.height += 0.5f;
                    speed += 1.5f;
                    break;
                case 4:
                    controllerPlayer.height += 0.5f;
                    speed += 1.5f;
                    break;
                case 2:
                    controllerPlayer.height += 0.5f;
                    speed += 1.5f;
                    break;
                case 0:
                    controllerPlayer.height = 3.8f;
                    speed = 10f;
                    isCrouched = false;
                    frameStep++;
                    break;
                default:
                    break;

            }
            frameStep--;
        }

        //checks for input to sprint
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSprint)
        {
            speed = 16f;
            isSprint = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isSprint)
        {
            speed = 10f;
            isSprint = false;
        }

        //Checks if the player is attempting to jump while grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            speed = 10f;
            controllerPlayer.height = 3.8f;
            frameStep = 0;
            velocity.y = Mathf.Sqrt(jumpHeight * -6f * gravity);
            isSprint = false;
        }

        //Moves the player using gravity variables when falling
        velocity.y += gravity * 3 * Time.deltaTime;
        controllerPlayer.Move(velocity * Time.deltaTime);
    }
}