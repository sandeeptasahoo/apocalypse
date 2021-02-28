using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    gamemanager gm;
    // Start is called before the first frame update
    void OnEnable()
    {
        gm=GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>();
        if(gm.Continue)
        {
            transform.position=gm.player;
            GetComponent<PlayerHealth>().currentHealth=GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>().player_health;
            GetComponent<PlayerHealth>().healthBar.setHealth(GetComponent<PlayerHealth>().currentHealth);
        }
    }
    void OnDisable()
    {
        gm.player=transform.position;
        gm.player_health=GetComponent<PlayerHealth>().currentHealth;
    }
}
