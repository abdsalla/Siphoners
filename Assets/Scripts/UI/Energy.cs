﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private float sunValue = 50f;
    private float chargeRate;

    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public float currentEnergy { get; set; }
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseEnergy(20);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {

            ChargeEnergy();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

            ReceiveDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {

            HealDamage(20);
        }

    }

    public void UseEnergy (float energyUsage)
    {
        currentEnergy -= energyUsage;
        energyBar.value = CalculateEnergy();
    }

    public void ChargeEnergy ()
    {

        if (sunValue <= 20 && sunValue > 0)
        {
            chargeRate = 5f;
        }
        else if (sunValue <= 60 && sunValue > 20)
        {
            chargeRate = 10f;
        }
        else if (sunValue <= 100 && sunValue > 60)
        {
            chargeRate = 30f;
        }
        else
        {
            chargeRate = 0f;
        }

        currentEnergy += chargeRate;
        energyBar.value = CalculateEnergy();
    }

    public void ReceiveDamage (float damagevalue)
    {
        currentHealth -= damagevalue;
        healthBar.value = CalculateHealth();
    }

    public void HealDamage (float healValue)
    {
        currentHealth += healValue;
        healthBar.value = CalculateHealth();
    }

    public float CalculateHealth ()
    {
        return currentHealth / maxHealth;
    }

    public float CalculateEnergy ()
    {
       return currentEnergy / maxEnergy;
    } 

}
