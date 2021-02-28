using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class generalgamemanagerclass 
{
    public bool Continue;
    public float[][] drons;
    public float[] player;
    public float[] mazeplayer;
    public float[][] portal_light_position;
    public float[][] portal_light_scale;
    public bool[] generator_switch;
    public bool[] light_switch;
    public float player_health;
    public float[] current_time;
    public bool[] isrunning;
    public bool battery_switch;
    public bool overworld;

    public generalgamemanagerclass(gamemanager gm)
    {
        int j=gm.drons.Length;
        drons=new float[j][];

        for(int i=0;i<j;i++)
        {
            drons[i]=new float[3];
            drons[i][0]=gm.drons[i].x;
            drons[i][1]=gm.drons[i].y;
            drons[i][2]=gm.drons[i].z;
        }

        player=new float[3];
        player[0]=gm.player.x;
        player[1]=gm.player.y;
        player[2]=gm.player.z;

        mazeplayer=new float[3];
        mazeplayer[0]=gm.mazeplayer.x;
        mazeplayer[1]=gm.mazeplayer.y;
        mazeplayer[2]=gm.mazeplayer.z;

        j=gm.portal_light_position.Length;
        portal_light_position=new float[j][];
        for(int i=0;i<j;i++)
        {
            portal_light_position[i]=new float[3];
            portal_light_position[i][0]=gm.portal_light_position[i].x;
            portal_light_position[i][1]=gm.portal_light_position[i].y;
            portal_light_position[i][2]=gm.portal_light_position[i].z;
        }

        j=gm.portal_light_scale.Length;
        portal_light_scale=new float[j][];
        for(int i=0;i<j;i++)
        {
            portal_light_scale[i]=new float[3];
            portal_light_scale[i][0]=gm.portal_light_scale[i].x;
            portal_light_scale[i][1]=gm.portal_light_scale[i].y;
            portal_light_scale[i][2]=gm.portal_light_scale[i].z;
        }

        generator_switch=gm.generator_switch;
        light_switch=gm.light_switch;
        player_health=gm.player_health;
        current_time=gm.current_time;
        isrunning=gm.isrunning;
        battery_switch=gm.battery_switch;
        overworld=gm.overworld;


    }
    
}
