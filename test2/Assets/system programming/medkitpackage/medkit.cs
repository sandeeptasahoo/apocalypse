using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    public Vector3 rotation_speed;
    public float health_gain;
    public GameObject particlesystem;
    
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(rotation_speed);
       
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if(player.tag=="Player")
        {
            float c;
            Quaternion a=Quaternion.Euler(0f,0f,0f);
            c=GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentHealth+health_gain;
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().currentHealth=Mathf.Clamp(c,0f,100f);
            Instantiate(particlesystem,transform.position,a);
            Destroy(transform.parent.gameObject);
            
        }
    }
}
