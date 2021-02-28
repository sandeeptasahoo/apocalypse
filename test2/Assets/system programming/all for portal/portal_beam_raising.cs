using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_beam_raising : MonoBehaviour
{
     Vector3 size;
     public GameObject portal_camera;
     public GameObject player_camera;

     public bool Generator_switch;
    public float risingfactor;
    float risingspeed;
    public float maxrisingspeed;
    public float risingaccelaration;
     Vector3 pos;
    public float max_light_height;
    float min_light_height;
    float initial_position;
    public bool light_source;
    AudioSource sound;
    public bool sound_status;
    
    void Awake()
    {
        initial_position=transform.position.y-6f;
        min_light_height=transform.localScale.y;
        sound_status=false;
    }
    void Start()
    {
        size=transform.localScale;
        pos=transform.position;
        sound=GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Generator_switch)
        {
            if(light_source==false)
            {
                portal_camera.SetActive(true);
                player_camera.SetActive(false);
            }
            light_source=true;
            if(transform.localScale.y<max_light_height)
            {
                raisebeam();
                
            }
            else
            {
                risingspeed=0f;
            }
        }
        else
        {
            if(transform.localScale.y>min_light_height)
            {
                decentbeam();
            }
            else
            {
                light_source=false;
                risingspeed=0f;
            }
        }
    }

    void raisebeam()
    {
        if(risingspeed<=maxrisingspeed)
        {
            risingspeed+=risingaccelaration*Time.deltaTime;
        }
        size.y+=(risingspeed*Time.deltaTime);
        pos.y=(initial_position+(risingfactor*(size.y)));
        transform.localScale=size;
        transform.position=pos;
        if(!sound_status)
        {
            sound.Play();
            sound_status=true;
        }
    }

    void decentbeam()
    {
        if(risingspeed<=maxrisingspeed)
        {
            risingspeed+=risingaccelaration*Time.deltaTime;
        }
        size.y-=(risingspeed*Time.deltaTime);
        pos.y=(initial_position+(risingfactor*(size.y)));
        transform.localScale=size;
        transform.position=pos;
        if(sound_status)
        {
            sound.Play();
            sound_status=false;
        }
    }
}
