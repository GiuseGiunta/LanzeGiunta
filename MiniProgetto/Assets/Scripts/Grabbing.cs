using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public Transform grabPos;
    public int gravità;
    public int throwForce = 500;
    GameObject grabbedObj;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        
           
            if (Input.GetKeyDown(KeyCode.Mouse1) && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10)  && hit.transform.tag == "Grabbable")
            {

               
                grabbedObj = hit.transform.gameObject;
           

            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                grabbedObj = null;
            }
            if (grabbedObj)
            {
            
             
           
              grabbedObj.GetComponent<Rigidbody>().velocity = (grabPos.position - grabbedObj.transform.position) * gravità;
           
             // grabbedObj.transform.position = grabPos.position;

              if (Input.GetKeyDown(KeyCode.Alpha2))
              {
                grabbedObj.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce);
                grabbedObj = null;
              }
               
            }
        
    }
}
