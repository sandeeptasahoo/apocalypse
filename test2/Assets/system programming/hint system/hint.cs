using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hint : MonoBehaviour
{
    public GameObject hint_video;
    public GameObject player;
    public Text instruction;
    public GameObject exclamation_mark;
    bool t=false;
    bool f=false;
    float player_distance;
    public float player_detection_range;
    public float player_access_distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_distance=Vector3.Distance(player.transform.position,transform.position);
        if(player_distance<player_detection_range)
        {
            f=true;
            exclamation_mark.SetActive(true);
        }
        else if(f)
        {
            f=false;
            exclamation_mark.SetActive(false);
        }
        if(player_distance < player_access_distance)
        {
            playeraccess();
        }
        else
        {
            if(t)
            {
                instruction.text=null;
                t=false;
            }
        }
    }
    void playeraccess()
    {
        if(!t)
            {
                instruction.text="Enter 'E' to look into the hint";
                t=true;
            }
            if(Input.GetKeyDown("e"))
            {
                instruction.text=null;
                hint_video.SetActive(true);
                t=false;
                gameObject.SetActive(false);
            }
    }
}
