using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlatform : Magnetic
{
    public Material positive;
    public Material negative;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(base.pole < 0 )
        {
            this.gameObject.GetComponent<Renderer>().material = negative;
        }
        if (base.pole > 0)
        {
            this.gameObject.GetComponent<Renderer>().material = positive;
        }
    }
}
