using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Start is called before the first frame update
    float angle;
    public float floating_speed;
    public float floating_amplitude;
    public float rotation_speed;
    Vector3 initial_pos;
    Vector3 pos;

    void Start()
    {
        initial_pos=transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        angle+=Time.deltaTime;
        pos=initial_pos;
        pos.y+=Mathf.Sin(angle*floating_speed)*floating_amplitude;
        transform.localPosition=pos;
        transform.Rotate(transform.up*rotation_speed*Time.deltaTime);
    }
}
