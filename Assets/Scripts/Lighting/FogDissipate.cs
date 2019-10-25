using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FogDissipate : MonoBehaviour
{
    //Variables
    private ParticleCollisionEvent dissipate;
    private ParticleSystem fog;
    private GameManager instance;

    public GameObject fogEmitter;

    void Start()
    {
        fog = fogEmitter.GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject fogEmitter)
    {

        Destroy(fogEmitter);

    }

}