using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raise_battery : MonoBehaviour
{
    public GameObject battery;
    public GameObject light1;
    public GameObject light2;
    public float max_size;
    Vector3 size;
    Vector3 pos;
    Vector3 pos_battery;
    public float risingspeed;
    public float risingfactor;
    // Start is called before the first frame update
    void OnEnable()
    {
        pos=transform.localPosition;
        size=transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(size.z<max_size)
        {
            size.z+=(risingspeed*Time.deltaTime);
            size.x+=risingspeed*Time.deltaTime/6;
            size.y=size.x;
            pos.y+=risingspeed*risingfactor*Time.deltaTime;
            transform.localScale=size;
            transform.localPosition=pos;
            battery.transform.localPosition=pos;
        }
        else
        {
            light1.SetActive(true);
            light2.SetActive(true);
            battery.GetComponent<battery>().enabled=true;
            GetComponent<raise_battery>().enabled=false;
        }
    }
}
