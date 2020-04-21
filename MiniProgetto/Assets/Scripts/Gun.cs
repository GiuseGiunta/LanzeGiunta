using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    RaycastHit hit;
    public float range;
    public ParticleSystem fire1; 
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            fire1.Play();

            if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, range))
            {
               GameObject obj =  Instantiate(fire, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(obj, 1.5f);

                if (hit.transform.gameObject.GetComponent<Magnetic>() != null)
                { 
                    hit.transform.gameObject.GetComponent<Magnetic>().pole *= -1;


                }
                


            }
        }

    }
}
