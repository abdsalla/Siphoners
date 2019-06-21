using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class werewolfController : MonoBehaviour
{
    public GameObject spawnNode;
    public Transform tf;
    private NavMeshAgent agent;
    public GameObject node;
    public float turnSpeed;
    public nodeSpawner scentNode;
    Transform[] nodelist;
    nodeSpawner node1;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();

        scentNode = GetComponent<nodeSpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(node.transform.position);
        RotateTowards(node.transform.localPosition);
        nodelist = nodeSpawner.scentNode;

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
}
