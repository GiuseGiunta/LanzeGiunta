﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermoving : MonoBehaviour
{
    public CharacterController controller;

   

    public float speed = 12f;
    public float gravity = -9.81f;
    public float JumpHeight = 5f;

    public Vector3 velocity;
    bool isGrounded;


    

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded & velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

       

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && velocity.y == -2 )
        {
            velocity.y = JumpHeight;
        }

        
        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


      

    }
}
