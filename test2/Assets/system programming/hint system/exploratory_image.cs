using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exploratory_image : MonoBehaviour
{
    public float speed;
    public int amplitude;
    RectTransform r;
    float value;
    float time;
    public float timer;
    bool t=true;
    // Start is called before the first frame update
    void Start()
    {
        r=GetComponent<RectTransform>();
        time=timer;
    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;
        if(time>0)
        {
            value+=speed*Time.deltaTime;
            r.localRotation=Quaternion.Euler(0,0,(Mathf.Sin(value*speed)*amplitude));
        }
        else if(time<timer*-1)
        {
            t=true;
            time=timer;
        }
        else if(t)
        {
            r.localRotation=Quaternion.Euler(0,0,0);
            t=false;
        }
        
    }
}
