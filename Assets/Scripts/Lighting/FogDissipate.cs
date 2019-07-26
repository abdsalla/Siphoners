using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FogDissipate : MonoBehaviour
{
    private ParticleCollisionEvent dissipate;
    private ParticleSystem fog;

    public GameObject fogEmitter;

    void Start()
    {
        fog = fogEmitter.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        
    }

    void OnParticleCollision(GameObject fogEmitter)
    {
        if (fog.gameObject.tag == "Fog")
        {
            Destroy(fog);
        }
    }

}
