using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_management : MonoBehaviour
{
    public int portal_index;
    gamemanager gm;
    portal_beam_raising bm;
   void OnEnable()
    {
        gm=GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>();
        bm=GetComponent<portal_beam_raising>();
        if(gm.Continue)
        {
            transform.localPosition=gm.portal_light_position[portal_index];
            transform.localScale=gm.portal_light_scale[portal_index];
            bm.Generator_switch=gm.generator_switch[portal_index];
            bm.light_source=gm.light_switch[portal_index];
            bm.sound_status=gm.light_switch[portal_index];
            if(bm.Generator_switch)
            {
                bm.portal_camera.GetComponent<camera_postal_display>().timer.SetActive(true);
            }
        }
        
    }
    void OnDisable()
    {
        gm.portal_light_position[portal_index]=transform.localPosition;
        gm.portal_light_scale[portal_index]=transform.localScale;
        gm.generator_switch[portal_index]=bm.Generator_switch;
        gm.light_switch[portal_index]=bm.light_source;
    }
}
