using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    //Variables
    public GameObject player;
    public GameObject currentPlayer;
    public Camera main;
    public CameraFollow cameraFollow;
    public Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        cameraFollow = main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer == null)
        {
            currentPlayer = Instantiate(player, tf.position, tf.rotation).GetComponentInChildren<PlayerMovement>().gameObject;
            cameraFollow.target = currentPlayer.transform;
        }
        
    }
}
