using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIAnimator : MonoBehaviour
{
    public Animator anim;           //The Animator Component
    private NavMeshAgent agent;     //The NavMesh Component
    private Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        input = agent.desiredVelocity;
        input = transform.InverseTransformDirection(input);
        anim.SetFloat("Horizontal", input.x);
        anim.SetFloat("Vertical", input.z);
    }
}
