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
    private Energy eRef;
    //private Health hp;              //The Health Component

    //Temp
    public int zombieDamage = 10;
    public float targetDistance;    //Distance from the AI to the player to stop at
    public TestSpawn playerSpawn;
    public GameObject player;
    private Vector3 input;
    public Animator anim;

    //Temp
    public float sightRadius = 20;

    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        tf = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){player = playerSpawn.currentPlayer;}
        //if(eRef == null){eRef = player.GetComponent<Energy>();}
        if (Vector3.Distance(player.transform.localPosition, tf.position) <= sightRadius)
        {
            GetComponent<ControllerAI1>().enabled = false;
            agent.SetDestination(player.transform.position);
            //Debug.Log(tf.position + " : " + agent.destination);
            RotateTowards(player.transform.localPosition);
        }
        else if (Vector3.Distance(player.transform.localPosition, tf.position) >= ((sightRadius)*(2)))
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

    private void Attack()
    {
       player.gameObject.GetComponentInChildren<Energy>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //simple temp kill mechanic 
        if (collision.gameObject == player.gameObject)
        {
            //eRef.ReceiveDamage(zombieDamage);
            Debug.Log("Dealt Damage");
            Destroy(player.gameObject);
        }
    }
}