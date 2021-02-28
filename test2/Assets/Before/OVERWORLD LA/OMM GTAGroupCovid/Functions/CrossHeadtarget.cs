using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHeadtarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform raycastOrigin;
    public Transform raycastDestination;
    //Camera mainCamera;
    Ray ray;
    RaycastHit hitinfo;
    void Start()
    {
        //mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = raycastOrigin.transform.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;
        if (Physics.Raycast(ray, out hitinfo))
        {
            transform.position = hitinfo.point;
        }

    }
}
