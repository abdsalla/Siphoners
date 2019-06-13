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
    //private Health hp;              //The Health Component
    public float targetDistance;    //Distance from the AI to the player to stop at
    public TestSpawn playerSpawn;
    public Transform player;

    //Temp
    public float sightRadius = 10;

    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        tf = GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = playerSpawn.currentPlayer.transform;
        }
        else if((player.position - tf.position).magnitude <= sightRadius)
        {
            agent.SetDestination(player.position);
            RotateTowards(player.position);
        }
        else if ((player.position - tf.position).magnitude <= (sightRadius * 1.5))
        {
            agent.SetDestination(tf.position);
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

    private void OnCollisionEnter(Collision collision)
    {
        //simple temp kill mechanic 
        if (collision.gameObject == player.gameObject)
        {
            Destroy(player.gameObject);
        }
    }

}
