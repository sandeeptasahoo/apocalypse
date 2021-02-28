using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dronmanager : MonoBehaviour
{
    gamemanager gm;
    public int dron_index;
    
   void OnEnable()
    {
        gm=GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>();
        if(gm.Continue)
        transform.position=gm.drons[dron_index];
    }
    void OnDisable()
    {
        gm.drons[dron_index]=transform.position;
    }
}
