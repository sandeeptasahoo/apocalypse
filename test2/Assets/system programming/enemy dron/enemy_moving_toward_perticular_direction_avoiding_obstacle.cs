using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_moving_toward_perticular_direction_avoiding_obstacle : MonoBehaviour
{
     Vector3 target_pos;
    Vector3 random_pos;
    public GameObject player;
     GameObject playertarget;
    public GameObject portal_light;
    public int speed;
    float rotationspeed;
    public float attack_time_rotation_speed;
    public float normal_time_rotation_speed;
    public int detectiondistance;
    public int rayoffset;
    public Vector3 enemy_roaming_max_coordinates;
    public Vector3 enemy_roaming_min_coordinates;
    public float enemyrange;
    public float attackrange;
    bool followlight;
    ParticleSystem muzzleflash;
    bool firing;
    float player_distance;
    float currenthealth;
    AudioSource audio_source;
    Vector3 diagonal_angle_detection;
    public float ground_clearance;
    


    
    

    void Start()
    {
        rotationspeed=normal_time_rotation_speed;
        random_pos=random_position();
        muzzleflash=gameObject.transform.GetChild(0).GetComponentInChildren<ParticleSystem>();
        muzzleflash.Stop();
        playertarget=player.transform.GetChild(1).gameObject;
        audio_source=GetComponent<AudioSource>();
        diagonal_angle_detection=new Vector3(1,-1,0);

        
    }
    void Update()
    {
        currenthealth=player.GetComponent<PlayerHealth>().currentHealth;
        move_toward_target();
        followlight=portal_light.transform.GetChild(0).gameObject.GetComponent<portal_beam_raising>().light_source;
    }
    void move_toward_target()
    {
        player_distance = Vector3.Distance(playertarget.transform.position, transform.position);
        decidetarget();
        look_at_target_direction();
        avoid_obstacle();
        moveforward();

    }
    
    void moveforward()
    {
        int spd;
        player_distance = Vector3.Distance(playertarget.transform.position, transform.position);
        if(player_distance<=attackrange && currenthealth>=0f)
        {
            spd=0;
            increase_volume();
            if(!firing)
            {
                rotationspeed=attack_time_rotation_speed;
                muzzleflash.Play();
                gameObject.GetComponent<AudioSource>().Play();
                firing=true;
            }
        }
        else
        {
            spd=speed;
            if(firing)
            {
                rotationspeed=normal_time_rotation_speed;
                gameObject.GetComponent<AudioSource>().Stop();
                audio_source.volume=0f;
                muzzleflash.Stop();
                firing=false;
            }
        }
        transform.position+=transform.forward * Time.deltaTime *spd;
    }

    void look_at_target_direction()
    {
        Quaternion rotation=Quaternion.LookRotation(target_pos-transform.position);
        transform.rotation=Quaternion.Slerp(transform.rotation,rotation,rotationspeed * Time.deltaTime);
    }

    void avoid_obstacle()
    {
        RaycastHit hit;
        Vector3 rayposition;
        rayposition=transform.position-(transform.right*rayoffset);
        Debug.DrawRay(rayposition,transform.forward*detectiondistance,Color.red);
         while(Physics.Raycast(rayposition,transform.forward,out hit, detectiondistance ) && hit.collider.gameObject.tag!="Player")
         {
             transform.Rotate(new Vector3(0,1,0));
         }
         Debug.DrawRay(transform.position,transform.forward*detectiondistance,Color.red);
         while(Physics.Raycast(transform.position,transform.forward,out hit, detectiondistance )&& hit.collider.gameObject.tag!="Player")
         {
             transform.Rotate(new Vector3(0,1,0));
         }
         Debug.DrawRay(transform.position,diagonal_angle_detection*ground_clearance,Color.red);
         while(Physics.Raycast(transform.position,diagonal_angle_detection,out hit, ground_clearance )&& hit.collider.gameObject.tag!="Player")
         {
             transform.Rotate(new Vector3(1,0,0));
         }
         Debug.DrawRay(transform.position+(transform.right*rayoffset),transform.forward*detectiondistance,Color.red);
         while(Physics.Raycast(transform.position+(transform.right*rayoffset),transform.forward,out hit, detectiondistance )&& hit.collider.gameObject.tag!="Player")
         {
             transform.Rotate(new Vector3(0,-1,0));
         }

         
    }

    Vector3 random_position()
    {
        
        float x=Random.Range(enemy_roaming_min_coordinates.x,enemy_roaming_max_coordinates.x);
        float y=Random.Range(enemy_roaming_min_coordinates.y,enemy_roaming_max_coordinates.y);
        float z=Random.Range(enemy_roaming_min_coordinates.z,enemy_roaming_max_coordinates.z);
        return new Vector3(x,y,z);
       
    }

    void decidetarget()
    {
        player_distance = Vector3.Distance(playertarget.transform.position, transform.position);
        float random_distance=Vector3.Distance(random_pos, transform.position);
        if(random_distance<=30f)
        {
            random_pos=random_position();
        }
        if(player_distance<=enemyrange && currenthealth>=0f )
        {
            target_pos=playertarget.transform.position;
        }
        else if(followlight)
        {
            target_pos=portal_light.transform.position;
        }
        else
        {
            //print("random_pos");
            target_pos=random_pos;
        } 
    }
    void increase_volume()
    {
        if(audio_source.volume<0.5f)
        {
            audio_source.volume+=Time.deltaTime;
        }
    }
}
