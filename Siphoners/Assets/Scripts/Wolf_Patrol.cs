using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Wolf_Patrol : MonoBehaviour
{
    trigger_patrol trig_patrol;

    [HideInInspector]
    public GameObject target;



    NavMeshAgent myAgent;
    public Transform[] points;
    int destPoint = 0;
    public float speed = 7f;

    
    [Header("Rangers")]
    public float agro_Radius;
    public float attackDistance;
    public float attackCoolDown;
    float startTimer;
    bool attacking = false;
    void OnEnable()
    {
        trig_patrol = GetComponentInChildren<trigger_patrol>();
        trig_patrol.agroRad = agro_Radius;

    }



    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = speed;
        myAgent.autoBraking = false;
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if (!myAgent.pathPending && myAgent.remainingDistance <= 0.5f)
        {
            NextPoint();
        }
        
    }
    void NextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        myAgent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
    void ChckDistance()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist <= attackDistance)
        {
            attacking = true;
            myAgent.isStopped = true;

        }
        else
        {
            myAgent.isStopped = false;
            myAgent.destination = target.transform.position;
            attacking = false;

        }
    }
    void Attack()
    {
        print("Attacking the player");
    }
}
