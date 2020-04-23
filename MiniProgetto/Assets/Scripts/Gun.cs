using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int range = 50;
    public int fireRate = 15;
    public int damage = 10;
    public int ImpactForce = 100;

    public ParticleSystem flame;
    public GameObject impactEffect;

    private float nextToShoot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButton("Fire1") && Time.time >= nextToShoot)
        {
            nextToShoot = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        flame.Play();

        RaycastHit hit;
       
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
      
        {
            GameObject obj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(obj, 1f);

            Target target = hit.transform.GetComponent<Target>();
            Rigidbody trb = hit.transform.GetComponent<Rigidbody>();

            if(target != null) { target.Damage(damage); }

            Vector3 impactDirection = hit.point - transform.position;

            if(trb != null) { trb.AddForceAtPosition( impactDirection.normalized * ImpactForce, transform.position ); }
        }
    }
}
