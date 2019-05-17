using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityUV : MonoBehaviour
{
    private AndroidJavaObject uvSensor = null;

    void Start()
    {
        if (uvSensor == null)
        {
            using(AndroidJavaClass pluginClass = new AndroidJavaClass("com.google.android.things.permission.uvsensorpull"))
            {
                if (pluginClass != null)
                {
                    uvSensor = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    uvSensor.Call("get_ADC_Val"); 
                    
                }
            }
        }
    }


}
