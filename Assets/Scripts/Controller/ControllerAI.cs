using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerAI : MonoBehaviour
{
    //Variables
    private Pawn pawn;              //The Pawn Component
    public Transform tf;
    public float turnSpeed;
    private NavMeshAgent agent;     //The NavMesh Component

    //Temp
    public int baseDamage = 10;
    public float targetDistance;    //Distance from the AI to the player to stop at
    public float sightRadius = 20;
    private Vector3 input;
    public Animator anim;

    private GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        tf = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        instance = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(instance.player == null){instance.player = instance.currentPlayer;}
        if (Vector3.Distance(instance.currentPlayer.transform.localPosition, tf.position) <= sightRadius)
        {
            GetComponent<ControllerAI1>().enabled = false;
            agent.SetDestination(instance.currentPlayer.transform.position);
            //Debug.Log(tf.position + " : " + agent.destination);
            RotateTowards(instance.currentPlayer.transform.localPosition);
        }
        else if (Vector3.Distance(instance.currentPlayer.transform.localPosition, tf.position) >= ((sightRadius)*(2)))
        {
            GetComponent<ControllerAI1>().enabled = true;
        }
        input = agent.desiredVelocity;
        input = transform.InverseTransformDirection(input);
        anim.SetFloat("Horizontal", input.x);
        anim.SetFloat("Vertical", input.z);
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


    private void OnCollisionEnter(Collision collision)
    {
        //simple temp kill mechanic 
        if (collision.gameObject == instance.currentPlayer)
        {
            Debug.Log("Dealt Damage");
            //Destroy(player.gameObject);
        }
    }
}