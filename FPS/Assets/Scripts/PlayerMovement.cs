//Chris Riordan
//6-14-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controls the player's movement
public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 6f;
    public float slowSpeed = 3f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isSlowed = false;

    //Implements gravity and inputs horizontal movement for the player
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (isSlowed)
        {
            controller.Move(move * slowSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    //If the player is hit by an enemy their horizontal speed is reduced
    public void slowMove(bool slow)
    {
        isSlowed = slow;
    }
    //Get method for the players vertical velocity
    public float getVelocity()
    {
        return velocity.y;
    }
    
}
