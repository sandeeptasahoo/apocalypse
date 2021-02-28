using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathcamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float flipspeed;
    public float rotationspeed;
    public float lowerdropheight;
    public float downspeed;
    Vector3 angles;
    public float deathspeed;
    float a;
    public GameObject bloodspill;
    public GameObject bloodsplash;
    void Start()
    {
        //angles.y+=rotationspeed*Time.deltaTime;
        //up=true;
        angles=transform.eulerAngles;
        angles.x=0;
        transform.eulerAngles=angles;
       // Instantiate(bloodsplash,transform);
    }

    // Update is called once per frame
    void Update()
    {
        faint();
    }

    void faint()
    {
        if(transform.position.y>lowerdropheight)
        {
            headflipingsinwave();
            Vector3 pos=transform.position;
            pos.y-=downspeed*Time.deltaTime;
            transform.position=pos;
        }
        else
        {
            deathhead();
        }
        
    }
    void headflipingsinwave()
    {
        angles=transform.eulerAngles;
        a+=Time.deltaTime*flipspeed;
        angles.x=360+Mathf.Sin(a)*30;
        angles.y+=rotationspeed*Time.deltaTime;
        transform.eulerAngles=angles;
    }
    void deathhead()
    {
        angles=transform.eulerAngles;
        if(angles.z<90)
        {
            angles.z+=Time.deltaTime*deathspeed;
        }
        else
        {
            //Destroy(transform.GetChild(0).gameObject);
            Instantiate(bloodspill,transform);
            this.enabled=false;
        }
        transform.eulerAngles=angles;
    }
   
}
