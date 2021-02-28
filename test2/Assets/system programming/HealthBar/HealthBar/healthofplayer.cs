using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthofplayer : MonoBehaviour
{
    float maxHealth=100;
    public float currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        
    }

    void Update()
    {
        
    }
    private void TakeDamage(float damage)
    {
        if(currentHealth>0)
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
        }
    }
}
