using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog_Spawn : MonoBehaviour
{
    public GameObject Fog;
    public GameObject currentFog;
  
    public Transform tf;

    //Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        
    }

    //Update is called once per frame
    void Update()
    {
        if (currentFog == null)
        {
            currentFog = Instantiate(Fog, tf.position, tf.rotation);
            
        }

    }
}
       






