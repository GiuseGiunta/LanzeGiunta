﻿using System.Collections;
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
       

        

        if (mag != null && mag.still == false)
        {
            Vector3 direction = other.transform.position - transform.position;
            float distance = direction.magnitude * distanceCoeff;

            if (distance < 1) distance = 1;


            direction.Normalize();


            Debug.DrawRay(transform.position,direction, Color.red);

           
               
                    other.transform.GetComponent<Rigidbody>().AddForce(direction * (pole * mag.pole) * (force * 1 / (distance * distanceCoeff)) /** Time.deltaTime*/);
            

           
        }


       
    }

  


}
