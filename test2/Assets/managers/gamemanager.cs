using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class gamemanager : MonoBehaviour
{
    
    public bool Continue;
    public Vector3[] drons;
    public Vector3 player;
    public Vector3 mazeplayer;
    public Vector3[] portal_light_position;
    public Vector3[] portal_light_scale;
    public bool[] generator_switch;
    public bool[] light_switch;
    public float player_health;
    public float[] current_time;
    public bool[] isrunning;
    public bool battery_switch;
    public string scenetoload;
    public bool overworld;

    

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void saveplayer()
    {
        saveload.savegame(this);
        Debug.Log("game saved");
    }

    public void Loadplayer()
    {
        generalgamemanagerclass data=saveload.Loadgame();
        int j=data.drons.Length;
        for(int i=0;i<j;i++)
        {
            drons[i].x=data.drons[i][0];
            drons[i].y=data.drons[i][1];
            drons[i].z=data.drons[i][2];
            
        }

        player.x=data.player[0];
        player.y=data.player[1];
        player.z=data.player[2];

        mazeplayer.x=data.mazeplayer[0];
        mazeplayer.y=data.mazeplayer[1];
        mazeplayer.z=data.mazeplayer[2];

        j=data.portal_light_position.Length;
        for(int i=0;i<j;i++)
        {
            portal_light_position[i].x=data.portal_light_position[i][0];
            portal_light_position[i].y=data.portal_light_position[i][1];
            portal_light_position[i].z=data.portal_light_position[i][2];
        }

        j=data.portal_light_scale.Length;
        for(int i=0;i<j;i++)
        {
            portal_light_scale[i].x=data.portal_light_scale[i][0];
            portal_light_scale[i].y=data.portal_light_scale[i][1];
            portal_light_scale[i].z=data.portal_light_scale[i][2];
        }

        generator_switch=data.generator_switch;
        light_switch=data.light_switch;
        player_health=data.player_health;
        current_time=data.current_time;
        isrunning=data.isrunning;
        battery_switch=data.battery_switch;
        overworld=data.overworld;
        Continue=true;
        SceneManager.LoadScene(scenetoload);


    }

   
    // Update is called once per frame
    
}
