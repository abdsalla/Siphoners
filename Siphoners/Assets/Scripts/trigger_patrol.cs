﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_patrol : MonoBehaviour
{
    Wolf_Patrol enm_pat;
    SphereCollider myCollider;
    public float agroRad;

    public AudioSource audioData;

    void Start()
    {
        enm_pat = GetComponentInParent<Wolf_Patrol>();
        myCollider = GetComponent<SphereCollider>();
        audioData = GetComponent<AudioSource>();
        myCollider.radius = agroRad;
        myCollider.isTrigger = true;

        
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            print("Player has enter zone");
            enm_pat.target = coll.gameObject;
            audioData.Play(0);
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("Player has left zone");
            enm_pat.target = null; 
        }

    }

}
