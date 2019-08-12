using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FogDissipate : MonoBehaviour
{
    //Variables
    private ParticleCollisionEvent dissipate;
    private ParticleSystem fog;

    public GameObject currentPlayer;
    public GameObject fogEmitter;
    public TestSpawn spawn;

    void Start()
    {
        fog = fogEmitter.GetComponent<ParticleSystem>();
    }

    void Update()
    {

        //Check to find the active player and not just the prefab
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
