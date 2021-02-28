using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenemanager : MonoBehaviour
{
    public GameObject Maze;
    
    public GameObject TPS;
    public GameObject OveroworldPlayer;
    gamemanager gm;
    public GameObject battery_light;
    public int activetimer;
    public bool battery_switch;
    bool t=false;
    
    void OnEnable()
    {
        gm=GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>();
        
        if(gm.Continue)
        {
            battery_switch=gm.battery_switch;
            if(battery_switch)
            {
                battery_light.SetActive(true);
                t=true;
            }
           /* if(gm.overworld)
            {
                OveroworldPlayer.SetActive(true);
                TPS.SetActive(true);
                Maze.SetActive(false);
            }
            else
            {
                Maze.SetActive(true);
                OveroworldPlayer.SetActive(false);
                TPS.SetActive(false);

            }
            */
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(activetimer==3 && !t)
       {
           t=true;
           battery_switch=true;
           battery_light.SetActive(true);
       }
       if(activetimer==0 && t)
       {
           t=false;
           battery_switch=false;
           battery_light.GetComponent<decent_battery>().enabled=true;
       }
    }

    void OnDisable()
    {
        gm.battery_switch=battery_switch;
    }
}
