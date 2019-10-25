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
    public int hp;              //The Health Component

    //Temp
    public int baseDamage = 10;
    public float targetDistance;    //Distance from the AI to the player to stop at
    public float sightRadius = 20;
    
    

    /*

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
        //if(eRef == null){eRef = player.GetComponent<Energy>();}
        if (Vector3.Distance(instance.player.transform.localPosition, tf.position) <= sightRadius)
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
        
    }

    */
}