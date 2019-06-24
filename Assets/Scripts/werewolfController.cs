using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class werewolfController : MonoBehaviour
{
    public GameObject spawnNode;
    private GameObject list;
    public Transform tf;
    private NavMeshAgent nav;
    public GameObject node;
    public float turnSpeed;
    public nodeSpawner scentNode;
    
    nodeSpawner node1;
    public List<Transform> waypoints;
    public int currentWaypoint = 0;


    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
        
    }
    // Start is called before the first frame update
    void Start()
    {

        tf = GetComponent<Transform>();

        scentNode = GetComponent<nodeSpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(node.transform.position);
        RotateTowards(node.transform.localPosition);
        
        //GetComponent<nodeSpawner>().scentNode[0];

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
    
    public void getNextWaypoint()
    {
        int maxWaypoints = waypoints.Count - 1;
        if (currentWaypoint < maxWaypoints)
        {
            currentWaypoint++;
        }
        else
        {
            currentWaypoint = 0;
        }
    }

}
