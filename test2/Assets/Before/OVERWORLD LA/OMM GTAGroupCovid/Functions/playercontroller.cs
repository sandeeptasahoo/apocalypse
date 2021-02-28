using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playercontroller : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Awake(){
        anim=GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetFloat("inputx",Input.GetAxis("Vertical"));
        anim.SetFloat("inputy",Input.GetAxis("Horizontal"));
        //anim.SetFloat("inputz", Input.GetAxis("Vertical1"));
        
        
    }
}
