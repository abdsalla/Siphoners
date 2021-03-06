﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    trigger_patrol trig_patrol;
    [Header("Patrol Points")]

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private float waitTime;

    [Header ("Patrol Settings")]

    public float startWaitTime = 1f;
    public GameObject player;
    public float sightRadius = 20;
    public Transform tf;
    private Vector3 input;
    public Animator anim;
    public float turnSpeed;
    Vector3 noisePosition;
    public float noiseTravelDistance = 50f;

    [Header("Patrol Trigger")]

    public float agro_Radius;
    public float attackDistance;
    public float attackCoolDown;
    float startTimer;
    bool attacking = false;
    [HideInInspector]
    public GameObject target;
    

    public float spinspeed = 3f;
    private bool canSpin = false;
    private bool aiHeardPlayer = false;
    public float spinTime = 3f;
    private float isSpinningTime;

    void OnEnable()
    {
        trig_patrol = GetComponentInChildren<trigger_patrol>();
        trig_patrol.agroRad = agro_Radius;
        
    }



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;
        waitTime = startWaitTime;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                agent.destination = points[destPoint].position;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.01f)
        {
            waitTime = startWaitTime;
            GotoNextPoint();
        }
        if (Vector3.Distance(player.transform.localPosition, tf.position) <= sightRadius)
        {
            
            agent.SetDestination(player.transform.position);
            Debug.Log(tf.position + " : " + agent.destination);
            RotateTowards(player.transform.localPosition);
        }
        else if (Vector3.Distance(player.transform.localPosition, tf.position) >= ((sightRadius) * (2)))
        {
            
        }
        input = agent.desiredVelocity;
        input = transform.InverseTransformDirection(input);
        anim.SetFloat("Horizontal", input.x);
        anim.SetFloat("Vertical", input.z);

        if (attacking == true)
        {
            startTimer += Time.deltaTime;
            if (startTimer >= attackCoolDown)
            {
                startTimer = 0f;
                Attack();
            }
        }
        if (target != null)
        {
            ChckDistance();
        }


    }
    void GoToNoisePosition()//AI is told to go to last spot for hearing 
    {
        agent.SetDestination(noisePosition);

        if (Vector3.Distance(transform.position, noisePosition) <= 5f && canSpin == true)
        {
            isSpinningTime += Time.deltaTime;

            transform.Rotate(Vector3.up * spinspeed, Space.World);

            if (isSpinningTime >= spinTime)
            {
                canSpin = false;
                aiHeardPlayer = false;
                isSpinningTime = 0f;
            }
        }
    }
    void NoiseCheck()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        if (distance <= noiseTravelDistance)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                noisePosition = PlayerMovement.playerPos;
                aiHeardPlayer = true;
                Debug.Log("making noise");
            }
            else
            {
                aiHeardPlayer = false;
                canSpin = false;
            }
        }
    }
    public void RotateTowards(Vector3 targetPoint)
    {
        //Find the Difference Between the Pawn and What We Want to Look At
        Vector3 vectorToLookDown = targetPoint - tf.position;
        //Get the Rotation
        Quaternion lookRotation = Quaternion.LookRotation(vectorToLookDown, tf.up);
        //Look There
        tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }
    void ChckDistance()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist <= attackDistance)
        {
            attacking = true;
            agent.isStopped = true;
            
        }
        else
        {
            agent.isStopped = false;
            agent.destination = target.transform.position;
            attacking = false;

        }
    }
    void Attack()
    {
        
        print("Attacking the player");
    }
}
