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
       
        

        if (mag != null && mag.still == false)
        {
            Vector3 direction = other.transform.position - transform.position;
            Debug.DrawRay(transform.position,direction, Color.red);

            if(pole == mag.pole || pole == -mag.pole && direction.magnitude > distanceToPull)
            other.transform.Translate(direction *(pole * mag.pole) *force * Time.deltaTime);
        }
    }

    public override void ChangeColor()
    {
    
        if (gameObject.GetComponent<Renderer>() != null)
        {
         
            if (pole < 0)
            {
                gameObject.GetComponent<Renderer>().material = negative;
            }
            if (pole > 0)
            {
                gameObject.GetComponent<Renderer>().material = positive;
            }
        }
    }


}
