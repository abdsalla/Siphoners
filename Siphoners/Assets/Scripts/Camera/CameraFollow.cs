using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetPosition;
    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;
    private GameManager instance;

    private void OnEnable()
    {
        instance = GameManager.Instance;
     
    }

    private void Start()
    {
        instance = GameManager.Instance;
        Debug.Log(instance);
        
    }
    private void Update()
    {
        target = instance.currentPlayer.transform;
    }
    private void LateUpdate()
    {
        Debug.Log(instance);
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        
        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition.x,offsetPosition.y,0);
        }
        else
        {
            transform.position = offsetPosition;
        }
        
        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }

}

