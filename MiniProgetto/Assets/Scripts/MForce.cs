using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MForce : Magnetic
{
   
    public float force;
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
        Vector3 direction = other.transform.position - transform.position;

        if (mag != null && mag.still == false)
        {
            
            if(mag.pole == pole || mag.pole == -pole && direction.magnitude > distanceToPull)
            other.transform.Translate(direction *(pole * mag.pole) *force * Time.deltaTime);
        }
    }

    
}
