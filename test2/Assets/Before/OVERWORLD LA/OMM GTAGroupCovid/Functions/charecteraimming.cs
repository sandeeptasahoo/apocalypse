using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class charecteraimming : MonoBehaviour
{   
        public float turnspeed=15f;
        Camera mainCamera;
        public float aimduration = 0.3f;
        public Rig aimlayer;
        raycastweapon weapon;
        

    // Start is called before the first frame update
    void Start()
    {
        mainCamera=Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        weapon = GetComponentInChildren<raycastweapon>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yoCamera=mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,yoCamera,0),turnspeed*Time.fixedDeltaTime);
    }
    private void LateUpdate()
    {   if (aimlayer)
        {
            if (Input.GetButton("Fire2"))
            {
                aimlayer.weight += Time.deltaTime / aimduration;
            }
            else
            {
                aimlayer.weight -= Time.deltaTime / aimduration;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.StartFirring();

        }
        if (Input.GetButtonUp("Fire1"))
            {
            weapon.StopFirring();
        }

    }
    
}
