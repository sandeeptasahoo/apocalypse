using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class battery : MonoBehaviour
{
    public GameObject player;
    public Text msg;
    public float player_access_range; 
    public float rotation_speed;
    public float floating_speed;
    public float floating_amplitude;
    float angle=0;
    bool t=false;
    
    void Start()
    {
       
        
    }

   
    void Update()
    {
        float playerdistance=Vector3.Distance(transform.position,player.transform.position);
        if(playerdistance<=player_access_range)
        {
            if(!t)
            {
                msg.text="Enter E to take the battery";
                t=true;
            }
            
            if(Input.GetKey("e"))
            {
                SceneManager.LoadScene("level complete");
            }
        }
        else
        {
            if(t)
            {
                msg.text=null;
                t=false;
            }
        }
        battery_show();
        
    }
    void battery_show()
    {
        angle+=Time.deltaTime;
        Vector3 pos=transform.localPosition;
        pos.y=Mathf.Sin(angle*floating_speed)*floating_amplitude;
        transform.localPosition=pos;
        transform.Rotate(transform.up*rotation_speed*Time.deltaTime);
    }
}
