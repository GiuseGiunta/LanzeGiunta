using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    [Range(-1,1)]
    public int pole = 0;
    public bool still;

    public Color positive;
    public Color negative;
    public Color neutral;
   
  
    

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
                gameObject.GetComponent<Renderer>().material.color = negative;
            }
            if (pole > 0)
            {
                gameObject.GetComponent<Renderer>().material.color = positive;
            }
            if(pole == 0)
            {
                gameObject.GetComponent<Renderer>().material.color = neutral;
            }
        }
    }

}
