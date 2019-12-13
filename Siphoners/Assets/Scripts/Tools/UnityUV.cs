using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityUV : MonoBehaviour, IUVSensor
{
    private AndroidJavaClass pluginClass = null;       // Variable to hold sensor (class)
    private AndroidJavaObject uvSensor = null;  // Variable to hold sensor (object)

    public Text textBox;                        // Variable to display UV Value
    public bool debug;                          // Variable that toggles debug mode on and off
    public int UVValue;                       // Variable to hold output from sensor

    public float delayTime  = 1.5f;             // Time between sensor readings
    private float nextUVCallTime = Time.time;   // Temp variable to hold next time we can read the sensor

    void Start()
    {
        // Set timer
        nextUVCallTime = Time.time + delayTime;


        if (pluginClass == null)
        {

            pluginClass = new AndroidJavaClass("com.google.android.things.permission.uvsensorpull.UVActivity");

            if (pluginClass != null)
            {
               uvSensor = pluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
        }
    }

    public float GetUVValue()
    {
        return UVValue;
    }

    public void GetUV ()
    {
        // Check if we can (timer) get the UV
        if (Time.time >= nextUVCallTime)
        {
            // Check if sensor object exists
            if (uvSensor != null)
            {
                // Get Sensor value
                UVValue = uvSensor.Call<int>("get_ADC_Val");
                uvSensor.Call("LEDTestBlink");

                // Reset timer
                nextUVCallTime = Time.time + delayTime;
            }
        }

    }

    void Update()
    {
        GetUV();

        // set text to UV sensor value for debug mode
        if (textBox != null && debug == true) 
        {
            textBox.text = "" + GetUVValue();
        }
    }

}