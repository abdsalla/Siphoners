using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestUVSensor : MonoBehaviour, IUVSensor
{

    public Text textBox;
    
    public void Update()
    {
        if (textBox != null)
        {
            textBox.text = "" + GetUVValue();
        }
    }

    public float GetUVValue()
    {
        return Random.Range(0,128);
    }

}
