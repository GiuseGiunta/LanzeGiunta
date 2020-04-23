using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    public GameObject parent;
    public int health;
    
    public void Damage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
        
    }

    public virtual void Die()
    {
        Destroy(parent);
    }
}
