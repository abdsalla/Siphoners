using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FogDissipate : MonoBehaviour
{
    private ParticleCollisionEvent dissipate;
    private ParticleSystem fog;
    public GameObject fogEmitter;
    public GameObject currentPlayer;
    public TestSpawn spawn;

    void Start()
    {
        fog = fogEmitter.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!currentPlayer)
        {
            currentPlayer = spawn.currentPlayer;
        }

        this.transform.position = currentPlayer.transform.position;

    }

    void OnParticleCollision(GameObject fogEmitter)
    {

        Destroy(fogEmitter);

    }

}
