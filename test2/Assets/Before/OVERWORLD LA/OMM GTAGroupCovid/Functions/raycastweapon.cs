using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class raycastweapon : MonoBehaviour
{
    public bool isfiring = false;
    public ParticleSystem muzzleflash;
    public ParticleSystem muzzleflash1;
    public ParticleSystem muzzleflash2;
    public ParticleSystem muzzleflash3;
    public TrailRenderer trailEffect;
    public Transform raycastOrigin;
    public Transform raycastDestination;
    public GameObject hiteffect;
    public ParticleSystem blood;
    public float Damagae = 10f;
    Ray ray;
    RaycastHit hitInfo;
  
    public void StartFirring()
    {
        isfiring = true;
        muzzleflash.Emit(1);
        muzzleflash1.Emit(1);
        muzzleflash2.Emit(1);
        muzzleflash3.Emit(1);
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDestination.position - raycastOrigin.position;
        var tracker = Instantiate(trailEffect, ray.origin, Quaternion.identity);
        tracker.AddPosition(ray.origin);
        Physics.Raycast(ray, out hitInfo);
        
            
            Debug.Log(hitInfo.transform.name);
        Debug.Log("hi");
        //hiteffect.transform.position = hitInfo.point;
        // hitInfo.transform.forward = hitInfo.normal;
        //hiteffect.Emit(1);
        if (hitInfo.transform.tag == "Enemy")
        {
            Instantiate(blood, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        }
        else {
            Instantiate(hiteffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            tracker.transform.position = hitInfo.point;
        }
        EnemyDamage target = hitInfo.transform.GetComponent<EnemyDamage>();
        if (target.tag=="Enemy")
        {
            target.TakeToDamage(Damagae);
        }
           Debug.Log("xyz");
           
        isfiring = false;
       
        
    }
    
    public void StopFirring()
    {
        isfiring = false;
        muzzleflash.Emit(0);
        muzzleflash1.Emit(0);
        muzzleflash2.Emit(0);
        muzzleflash3.Emit(0);
    }
}
