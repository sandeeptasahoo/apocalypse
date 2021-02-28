using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera_postal_display : MonoBehaviour
{
    public GameObject portal_light;
    Transform target_position;
    public Transform upper_target;
    public Transform lower_target;
    public GameObject generator;
    public GameObject timer;
    public Transform dron_to_approach;
    public float dron_approach_distance;
    public float dron_approach_speed;
    public float orbiting_speed;
    public float Upward_speed;
    public float maximum_height_of_camera;
    public Vector3 startpoint;
    public float max_looking_height;
    bool target_flag=true;
    int shootindex=1;
    float speed;
    float rotation_damp=1;
    public float dron_portal_approach_distance;
    bool dronreach=false;
    public bool time;
    public float timers;
    
    // Start is called before the first frame update
    void Start()
    {
        time=true;
        //startpoint.x=portal_light.transform.x;

    }
    void Update()
    {
        if(time)
        {
            generator.GetComponent<generator_switch>().msg.text="Click On ENTER to skip";
            generator.GetComponent<generator_switch>().execution=false;
            time=false;
            if(portal_light.GetComponent<portal_beam_raising>().Generator_switch)
            {
                target_position=upper_target;
                transform.position=startpoint;
                speed=dron_approach_speed;
                rotation_damp=1;
                transform.LookAt(target_position);
                shootindex=1;
            }
            else
            {
                Vector3 p=transform.position;
                p.y=maximum_height_of_camera;
                transform.position=p;
                target_position=lower_target;
                timers=8;
                transform.LookAt(target_position);
               
            }
        }
        if(portal_light.GetComponent<portal_beam_raising>().Generator_switch)
        {
            shooting();
            if(Input.GetKey(KeyCode.Return))
            {
                timer.SetActive(true);
                loadnextscene();
            }
            
        }
        else 
        {
            shootportalbeamdecent();
            if(Input.GetKey(KeyCode.Return))
            {
                loadnextscene();
            }
        }
        
       
    }

    void shooting()
    {
        if(shootindex==1)
        {
            shootportalbeam();
        }
        else if(shootindex==2)
        {
            shootdronaproach();
        }

    }

    void shootdronaproach()
    {
        if(target_flag==false)
        {
            target_position=dron_to_approach;
            rotation_damp=3;
            target_flag=true;
        }
        look_at_target_direction();
        moveforward();
    }

    void moveforward()
    {
        
        float camera_distance= Vector3.Distance(target_position.position, transform.position);
        if(camera_distance<dron_approach_distance)
        {
            dronreach=true;
            speed=0f;
        }
        else if(dronreach)
        {
            dronreach=false;
            timer.SetActive(true);
            loadnextscene();
        }
        if(Vector3.Distance(dron_to_approach.position,lower_target.position)<dron_portal_approach_distance)
        {
            timer.SetActive(true);
            loadnextscene();
        }
        transform.position+=transform.forward * Time.deltaTime *speed;
    }

    void loadnextscene()
    {
        portal_light.GetComponent<portal_beam_raising>().player_camera.SetActive(true);
        portal_light.GetComponent<portal_beam_raising>().portal_camera.SetActive(false);
        generator.GetComponent<generator_switch>().msg.text=null;
        generator.GetComponent<generator_switch>().textshow=false;
        generator.GetComponent<generator_switch>().t=false;
        generator.GetComponent<generator_switch>().execution=true;
        time=true;
        this.gameObject.SetActive(false);
        

    }
    void shootportalbeam()
    {
        if(target_position.position.y>max_looking_height && target_flag)
        {
            target_position=lower_target;
            target_flag=false;
        }
        look_at_target_direction();
        if(transform.position.y<maximum_height_of_camera)
        {
            moveUp();
        }
        else
        {
            shootindex=2;
        }
        transform.RotateAround(portal_light.transform.position,Vector3.up,orbiting_speed);
        
    }

     void look_at_target_direction()
    {
        Quaternion rotation=Quaternion.LookRotation(target_position.position-transform.position);
        transform.rotation=Quaternion.Slerp(transform.rotation,rotation, rotation_damp*Time.deltaTime);
    }

    void moveUp()
    {
        Vector3 pos=transform.position;
        pos.y+=Upward_speed*Time.deltaTime;
        transform.position=pos;
    }

     void moveDown()
    {
        Vector3 pos=transform.position;
        pos.y-=10*Time.deltaTime;
        transform.position=pos;
    }

    void shootportalbeamdecent()
    {
        look_at_target_direction();
        timers-=Time.deltaTime;
        if(timers<0)
        {
           loadnextscene();
        }
        
        transform.RotateAround(portal_light.transform.position,Vector3.up,0.05f);
        
    }
}
