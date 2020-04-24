using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagGrapple : MonoBehaviour
{
    RaycastHit hit;
    public float range;
    public ParticleSystem flame;
    public GameObject mag;
    

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

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
            {
               GameObject obj =  Instantiate(mag, hit.point, Quaternion.LookRotation(hit.normal));
                obj.GetComponent<Magnetic>().pole = 1;
                obj.transform.SetParent(hit.transform);
                if (hit.transform.GetComponent<Rigidbody>())
                { obj.transform.GetComponent<FixedJoint>().connectedBody = hit.transform.GetComponent<Rigidbody>(); }
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            flame.Play();

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
            {
                GameObject obj = Instantiate(mag, hit.point, Quaternion.LookRotation(hit.normal));
                obj.GetComponent<Magnetic>().pole = -1;
                obj.transform.SetParent(hit.transform);
                if (hit.transform.GetComponent<Rigidbody>())
                { obj.transform.GetComponent<FixedJoint>().connectedBody = hit.transform.GetComponent<Rigidbody>(); }
            }
        }
    }
}
