using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerAI : MonoBehaviour
{
    //Variables
    private NavMeshAgent agent;     //The NavMesh Component
    private Pawn pawn;              //The Pawn Component
    private Energy eRef;
    //private Health hp;              //The Health Component

    //Temp
    public int zombieDamage = 10;
    public float sightRadius = 10;
    public float turnSpeed;
    public float targetDistance;    //Distance from the AI to the player to stop at
    public TestSpawn playerSpawn;
    public Transform player;
    public Transform tf;


    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        tf = GetComponent<Transform>();
        eRef = GetComponent<Energy>();
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
            eRef.ReceiveDamage(zombieDamage);
            Debug.Log("Dealt Damage");
            //Destroy(player.gameObject);
        }
    }
}