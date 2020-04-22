using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticGun : MonoBehaviour
{
    RaycastHit hit;
    public float range;
    public ParticleSystem flame; 
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            flame.Play();

            if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, range))
            {
               GameObject obj =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(obj, 1.5f);

                if (hit.transform.gameObject.GetComponent<Magnetic>() != null)
                { 
                    hit.transform.gameObject.GetComponent<Magnetic>().pole *= -1;


                }
                


            }
        }

    }
}
