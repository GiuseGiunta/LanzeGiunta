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

    public GameObject empty;
    GameObject step;
   public bool pizza;
    

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
            step = null;
        }


        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
       
        

        if(Physics.Raycast(transform.position, -transform.up, out hit, 1.09f))
        {
            if (pizza) { StartCoroutine(Step()); }
        }



    }

    IEnumerator Step()
    {
        pizza = false;
       
          step = Instantiate(empty, hit.point, transform.rotation);
        
        

        this.transform.SetParent(step.transform);
        step.transform.SetParent(hit.transform);

        yield return new WaitForSeconds(1);

        this.transform.parent = null;

        Destroy(step);

        pizza = true;
        
    }
}
