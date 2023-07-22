using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
        
    void Start()
    {
        currentHealth = maxHealth;
        Application.targetFrameRate = 60;
    }

    void TakeDamage()
    {
        currentHealth -= 10;
        
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>() != null && (other.gameObject.GetComponent<Bullet>().team == Bullet.Team.Player))
        {
            TakeDamage();
        }
    }
}
