using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_switching : MonoBehaviour
{
    public Camera FPS_Cam;
    public Camera TPS_Cam;
    bool tpsCam = true;
    void Start()
    {
        FPS_Cam.enabled = !tpsCam;
        TPS_Cam.enabled = tpsCam;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            tpsCam = !tpsCam;
            FPS_Cam.enabled = !tpsCam;
            TPS_Cam.enabled = tpsCam;
        }
    }
}
