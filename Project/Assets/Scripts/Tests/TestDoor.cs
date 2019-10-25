using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoor : MonoBehaviour
{
    private Lock doorLock;

    // Start is called before the first frame update
    void Start()
    {
        doorLock = GetComponent<Lock>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!doorLock.isLocked)
        {
            Destroy(gameObject);
        }
    }
}
