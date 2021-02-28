﻿using UnityEngine;

public class MazePlayerHealth : MonoBehaviour
{
    float maxHealth = 100;
     public float currentHealth;
    public HealthBar healthBar;
    public float damage ;//0.1f
    public float trap_damage;
    public GameObject smoke;
    Vector3 angle = new Vector3(-90f, 0f, 0f);
    bool Switch = true;
    float time = 0f;
    float startTime;
    public float coolDown;
    bool medKit = false;

    private void OnEnable()
    {
        healthBar.setHealth(currentHealth);
        
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        startTime = time;
    }

    void Update()
    {
        time += Time.deltaTime;
        //healthBar.setHealth(currentHealth);
        //setHealth();
    }

    void OnParticleCollision(GameObject collider)
    {
        TakeDamage(damage);
    }
    void OnTriggerEnter(Collider trap)
    {
        if(trap.tag=="trap")
        {
            TakeDamage(trap_damage);
        }

        if(trap.tag=="MedKit")
        {
            float c;
            c = currentHealth + trap.GetComponent<medkit>().health_gain;
            currentHealth = Mathf.Clamp(c, 0f, 100f);
            healthBar.setHealth(currentHealth);
            
        }
    }

 
    private void TakeDamage(float damage)
    {
        if(currentHealth>0 && time >= startTime + coolDown)
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
            startTime = time;
        }
        /*else if(Switch)
        {
            Quaternion angles=Quaternion.Euler(angle);
            Instantiate(smoke,transform.position,angles);
            gameObject.SetActive(false);
            //Switch=false;
            
        }*/
    }

}
