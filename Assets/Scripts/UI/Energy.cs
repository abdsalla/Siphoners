using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float currenEnergy { get; set; }
    public float maxEnergy { get; set; }
    public Slider energyBar;


    void Start()
    {
        maxEnergy = 50f;

        currenEnergy = maxEnergy;
        energyBar.value = maxEnergy;
    }

    void Update()
    {
        //Testing Purposes
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseEnergy(20);
        }
    }

    public void UseEnergy (float damageValue)
    {
        currenEnergy -= damageValue;
        energyBar.value = CalculateEnergy();
    }

    public void Charge(float chargeRate)
    {

    }

    public float CalculateEnergy()
    {
       return currenEnergy / maxEnergy;
    } 

}
