using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FogDissipate : MonoBehaviour
{
    private ParticleCollisionEvent dissipate;
    private ParticleSystem fog;

    public GameObject fogEmitter;
    public GameObject player;
    public GameObject currentPlayer;

    void Start()
    {
        fog = fogEmitter.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        this.transform.position = currentPlayer.transform.position;

    }

    void OnParticleCollision(GameObject fogEmitter)
    {
        if (fog.gameObject.tag == "Fog")
        {
            Destroy(fog);
        }
    }

}
