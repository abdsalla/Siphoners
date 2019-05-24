using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;
    private Vector3 targetPosition;

    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    void OnDrawGizmos()
    {

    }

    void LateUpdate()
    {
        targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        transform.LookAt(follow);
    }
}
