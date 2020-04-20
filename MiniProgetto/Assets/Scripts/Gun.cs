using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    RaycastHit hit;
    public float range;
    public Color blue;
    public Color red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, range))
            {
                if (hit.transform.gameObject.GetComponent<Magnetic>() != null)
                { 
                    hit.transform.gameObject.GetComponent<Magnetic>().pole *= -1;


                }
                


            }
        }

    }
}
