using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    [Range(-1,1)]
    public int pole = 0;
    public bool still;
    public Material negative;
    public Material positive;
    

    private void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ChangeColor();
    }

    public  virtual void ChangeColor()
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
