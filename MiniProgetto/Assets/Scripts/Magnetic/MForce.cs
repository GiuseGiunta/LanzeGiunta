using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MForce : Magnetic
{
   
    public float force;
    [Range(0.0001f,1)]
    public  float distanceCoeff = 1;
    public float distanceToPull;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Magnetic mag = other.GetComponent<Magnetic>();

        Rigidbody rb = other.GetComponent<Rigidbody>();

        

        if (mag != null && rb != null)
        {
            Vector3 direction = other.transform.position - transform.position;
            float distance = direction.magnitude * distanceCoeff;

            if (distance < 1) distance = 1;


            


           

           
               
            rb.AddForce(direction.normalized * (pole * mag.pole) * (force  / (distance)) /** Time.deltaTime*/);

            if (mag.pole == -pole && mag.still && other.GetComponent<MForce>())
            {
              rb.AddForce(direction.normalized * (pole * mag.pole) * (other.GetComponent<MForce>().force * 1 / distance));
            }
           
        }


       
    }

    public override void ChangeColor()
    {
        base.ChangeColor();

        if(force < 0)
        {
            pole *= -1;
            force *= -1;
        }
    }




}
