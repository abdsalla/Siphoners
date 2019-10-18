﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WallCreeperController : MonoBehaviour
{

    // Waypoint and NavMesh variables to make patrol work
    public Transform[] moveSpots;
    private int randomSpot;

    NavMeshAgent nav;

    public float startWaitTime = 1f;

    private float waitTime;

    // Boolean variables to control whether or not the WallCreeper has its certain special actions
    public bool inWall;
    public bool isCrying;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        inWall = false;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol() //Patrol state for AI goes to set waypoints. 
    {
        nav.SetDestination(moveSpots[randomSpot].position);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }



    /*
    ***IDEAS FOR HOW TO HANDLE THE WALL CREEPER***

    Have a variable that handles whether or not the creeper is in a wall, that will handle whether or not it can be damaged
    
    Use the same setup for sight and all of that as the zombo and werewolfboyo, but also add in a wall reach variable to check if a player could be attacked from inside the wall

    Make a bool variable to activate and deactivate the crying sound

    */
}
