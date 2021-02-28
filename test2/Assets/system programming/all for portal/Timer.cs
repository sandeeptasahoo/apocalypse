
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Timer : MonoBehaviour
{
   
    public GameObject portal;
    public Text timeText;
    //lines..17 to 24 to set time for the editor....Set the timer
    [Header("Time Values")]
    [Range(0, 60)]
    public int sec;
    [Range(0, 60)]
    public int min;
    [Range(0, 24)]
    public int hrs;
    public float currentsec;
    public int timerDefault;
    public bool timerIsRunning =true;
    public float lapsetime;

    gamemanager gm;
   scenemanager sm;
    public int timer_index;
    
   void OnEnable()
    {
        gm=GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>();
        sm=GameObject.FindGameObjectWithTag("scenemanager").GetComponent<scenemanager>();
        if(gm.Continue)
        {
            currentsec=gm.current_time[timer_index];
            timerIsRunning=gm.isrunning[timer_index];
            sm.activetimer+=1;
        }
        else
        {
            timerDefault = (sec + (min * 60) + (hrs * 60 * 60));
            currentsec = timerDefault;
        }
    }
    void OnDisable()
    {
        gm.current_time[timer_index]=currentsec;
        gm.isrunning[timer_index]=timerIsRunning;
        sm.activetimer-=1;
    }

    void Update()
    {
        
        if (timerIsRunning)
        {
            if (currentsec > 0)
            {
                currentsec -= Time.deltaTime;
                DisplayTime(currentsec);
            }
            else 
            {
                currentsec = 0;
                timerIsRunning = false;
                portal.GetComponent<portal_beam_raising>().Generator_switch=false;
                portal.GetComponent<portal_beam_raising>().portal_camera.SetActive(true);
                portal.GetComponent<portal_beam_raising>().player_camera.SetActive(false);
            }

        }
        else
        {
            currentsec -= Time.deltaTime;
            if(currentsec<-1f*lapsetime)
            {
                currentsec=timerDefault;
                timerIsRunning=true;
                //setoff the portal;
                gameObject.SetActive(false);
            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeText.text =TimeSpan.FromSeconds(timeToDisplay).ToString(@"hh\:mm\:ss");  
    }
    

}
