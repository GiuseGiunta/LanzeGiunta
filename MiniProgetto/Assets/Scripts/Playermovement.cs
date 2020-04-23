using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public CharacterController controller;
    RaycastHit hit;

   

    public float speed = 12f;
    public float gravity = -9.81f;
    public float JumpHeight = 5f;

    public Vector3 velocity;
    bool isGrounded;


    float xHook;
    float zHook;
    float yHook;

    

    public bool pizza = true;
    

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
       
        

        if(Physics.Raycast(transform.position, -transform.up, out hit, 1.09f))
        {
            float xDistance = hit.transform.position.x;
            float zDistance = hit.transform.position.z;
            float yDistance = hit.transform.position.y;
            
            if(!pizza)
            {
                transform.position = new Vector3(transform.position.x + (xDistance - xHook), transform.position.y + (yDistance - yHook), transform.position.z + (zDistance - zHook)) ;
            }


            xHook = hit.transform.position.x ;
            zHook = hit.transform.position.z ;
            yHook = hit.transform.position.y;

            pizza = false;

        }
        else { pizza = true; }
     

       

    }

   
    
}
