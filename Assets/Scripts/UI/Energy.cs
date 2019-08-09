﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Energy : MonoBehaviour
{
    //Variables
    private float sunValue = 50f;

    public bool solarCharged = false;
    public float additionalCost;
    public float chargeRate;
    public float currentEnergy { get; set; }
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public float maxEnergy { get; set; }
    
    public Slider energyBar;
    public Slider healthBar;


    void Start()
    {
        maxHealth = 100f;
        maxEnergy = 100f;
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        energyBar.value = maxEnergy;
        healthBar.value = maxHealth;
    }

    void Update()
    {
        //Testing Purposes
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseEnergy(20);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

            ReceiveDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {

            HealDamage(20);
        }*/

        if (Input.GetKey(KeyCode.Mouse0))
        {
            ChargeEnergy();
        }

        else if (Input.GetKey(KeyCode.Mouse1))
        {
            SolarCharge();
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            SolarRevert();
        }

    }



    //Called for player energy depletion
    public void UseEnergy (float energyUsage)
    {
        currentEnergy -= energyUsage;
        energyBar.value = CalculateEnergy();
    }

    //Called for player recharge
    public void ChargeEnergy ()
    {

        if (sunValue <= 20 && sunValue > 0)
        {
            chargeRate = .01f;
        }
        else if (sunValue <= 60 && sunValue > 20)
        {
            chargeRate = .25f;
        }
        else if (sunValue <= 100 && sunValue > 60)
        {
            chargeRate = .50f;
        }
        else
        {
            chargeRate = 0f;
        }

        currentEnergy += chargeRate;
        energyBar.value = CalculateEnergy();
    }


    // PLayer damage received
    public float ReceiveDamage (float damageValue)
    {
        currentHealth -= damageValue;
        healthBar.value = CalculateHealth();
        return currentHealth;
    }
 
    //Player damage replenish
    public float HealDamage (float healValue)
    {
        currentHealth += healValue;
        healthBar.value = CalculateHealth();
        return currentHealth;
    }

    public float CalculateHealth ()
    {
        return currentHealth / maxHealth;
    }

    public float CalculateEnergy ()
    {
       return currentEnergy / maxEnergy;
    }

    public void SolarCharge()
    {
        solarCharged = true;
        UseEnergy(additionalCost);
    }

    public void SolarRevert()
    {
        solarCharged = false;
    }

}
