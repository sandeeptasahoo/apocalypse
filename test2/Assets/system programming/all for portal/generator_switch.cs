using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generator_switch : MonoBehaviour
{
    public float distance;
    public Text msg;
    public string statement;
    public GameObject player;
    public GameObject portal;
    float dist;
    public bool t;
    bool t1;
    public bool execution;
    float time;
    public bool textshow;
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        t=false;
        textshow=false;
        execution=true;
        t1=false;
    }

    // Update is called once per frame
    void Update()
    {
        dist=Vector3.Distance(player.transform.position,transform.position);
        if(dist<distance)
        {
            if(t==false && textshow==false)
            {
                msg.text=statement;
                t=true;
            }
            if(Input.GetKeyDown("e"))
            {
                if(execution)
                {
                    if(portal.GetComponent<portal_beam_raising>().Generator_switch==false)
                    {
                        portal.GetComponent<portal_beam_raising>().Generator_switch=true;
                        textshow=true;
                    }
                    else
                    {
                        timer.GetComponent<Timer>().currentsec=timer.GetComponent<Timer>().timerDefault;
                        msg.text="Generator Time was reset";
                        t1=true;
                        time=1.5f;

                    }
                }
            }
            if(t1)
            {
                time-=Time.deltaTime;
                if(time<0)
                {
                    t1=false;
                    t=false;
                    textshow=false;
                }
            }

        }
        else
        {
            if(t==true)
            {
                msg.text=null;
                t=false;
                textshow=false;
            }
        }
    }

}
