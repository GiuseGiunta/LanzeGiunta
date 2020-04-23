using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMag : MForce
{
    public ParticleSystem effect;


    public GameObject impactForce;


    // Start is called before the first frame update
    void Start()
    {
       GameObject obj = Instantiate(impactForce, transform.position, transform.rotation);

        Destroy(obj, 1f);

        if(base.pole < 0)
        {
            var main = effect.main;
            main.startColor = new Color(0, 67, 245, 150);
        }
        effect.Play();
    }


    public override void ChangeColor()
    {
        
    }
}
