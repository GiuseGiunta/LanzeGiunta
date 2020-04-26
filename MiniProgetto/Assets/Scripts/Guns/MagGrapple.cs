using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagGrapple : MonoBehaviour
{
    RaycastHit hit;
    public float range;
    public int magInGame = 0;
    public int maxMags = 4;
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
            if (magInGame < maxMags)
            {
                flame.Play();

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
                {

                    GameObject obj = Instantiate(mag, hit.point, Quaternion.LookRotation(hit.normal)); /*Pools.instance.Spawn("LittleMag", hit.point, Quaternion.LookRotation(hit.normal));*/

                    obj.GetComponent<Magnetic>().pole = 1;
                    obj.transform.SetParent(hit.transform);

                    if (hit.transform.GetComponent<Rigidbody>())
                    { obj.transform.GetComponent<FixedJoint>().connectedBody = hit.transform.GetComponent<Rigidbody>(); }

                    magInGame++;
                }
            }
            else { UImanager.instance.MagWarning(); }
        }

       


        if (Input.GetButtonDown("Fire2") )
        {
            if (magInGame < maxMags)
            {
                flame.Play();

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
                {

                    GameObject obj = Instantiate(mag, hit.point, Quaternion.LookRotation(hit.normal)); /*Pools.instance.Spawn("LittleMag", hit.point, Quaternion.LookRotation(hit.normal));*/

                    obj.GetComponent<Magnetic>().pole = -1;
                    obj.transform.SetParent(hit.transform);

                    if (hit.transform.GetComponent<Rigidbody>())
                    { obj.transform.GetComponent<FixedJoint>().connectedBody = hit.transform.GetComponent<Rigidbody>(); }

                    magInGame++;
                }
            }
            else { UImanager.instance.MagWarning(); }
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            magInGame = 0;
        }

    }
}
