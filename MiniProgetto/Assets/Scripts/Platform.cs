using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("stonks");

        if (other.tag == "Player")

        { other.transform.SetParent(this.transform); }

        Debug.Log(other.transform.parent);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.transform.SetParent(null);
    }

}
