using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeSpawner : MonoBehaviour
{
    //varaibles 
    public GameObject spawn;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public Transform[] nodeList;

    //list of node points 
    static List<GameObject> scentNode = new List<GameObject>();
    int scentListSize;

    public void Awake()
    {
        scentNode.Add(spawn); //add to list 
        scentListSize = scentNode.Count; 
        Debug.Log(scentListSize); //too see if list is increasing 
    }
    static GameObject FindObjectWithScent()//trying to add node to list 
    {
        for (int i = 0; i < scentNode.Count; i++)
        {
            scentManager sm = scentNode[i].GetComponent<scentManager>();//not sure how this wil work
            if (sm != null && sm.node == true) return scentNode[i];
        }
        return null;
    }


    void Start()
    {
        InvokeRepeating("spawnObject", spawnTime, spawnDelay); //spawns out node and then checks the start time and delay 
    }

    public void spawnObject()
    {
        Instantiate(spawn, transform.position, transform.rotation); //spawns node at posiiton 
        
        if (stopSpawning)
        {
            CancelInvoke("spawnObject");//stops the time counter for spawner 
        }
    }
}
