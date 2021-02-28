using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing_angle : MonoBehaviour
{
    GameObject player;
    float rotationspeed;
    float attackrange;
    ParticleSystem muzzleflash;
    bool firing;
    
    void Start()
    {
        muzzleflash=GetComponentInChildren<ParticleSystem>();
        muzzleflash.Stop();
        rotationspeed=GetComponentInParent<enemy_moving_toward_perticular_direction_avoiding_obstacle>().normal_time_rotation_speed;
        attackrange=GetComponentInParent<enemy_moving_toward_perticular_direction_avoiding_obstacle>().attackrange;
        player=GetComponentInParent<enemy_moving_toward_perticular_direction_avoiding_obstacle>().player;
        
    }
    void Update()
    {
        float player_distance = Vector3.Distance(player.transform.position, transform.position);
        if(player_distance<=attackrange)
        {
            Quaternion rotation=Quaternion.LookRotation(player.transform.position-transform.position);
            transform.rotation=Quaternion.Slerp(transform.rotation,rotation,rotationspeed * Time.deltaTime);
            if(!firing)
            {
                muzzleflash.Play();
                firing=true;
            }
        }
        else
        {
            if(firing)
            {
                muzzleflash.Stop();
                firing=false;
            }
        }
       
    }


}
