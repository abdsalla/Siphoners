using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    //Variables
    public Item key;    //Key item needed to unlock door
    public bool isLocked = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision Detected");
        for (int i = 0; collider.GetComponent<Inventory>().items.Count > i; i++)
        {
            Debug.Log("Trying key");
            if (collider.GetComponent<Inventory>().items[i] == key)
            {
                Debug.Log("KeyWorked");
                isLocked = false;
            }
        }
    }
}
