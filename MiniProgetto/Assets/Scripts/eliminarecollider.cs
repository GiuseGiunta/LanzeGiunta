using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminarecollider : MonoBehaviour
{
    public GameObject off;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            off.GetComponent<BoxCollider>().enabled=false;
        }
        else
        {
            off.GetComponent<BoxCollider>().enabled = true;
        }
    }
}

