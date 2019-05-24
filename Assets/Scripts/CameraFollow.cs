using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset;

    private Transform tf;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //new postition of the camera is players(targetobject) position plus designer set offset.
        tf.position = targetObject.position + offset;
        tf.LookAt(targetObject.position);

    }
}
