using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Energy : MonoBehaviour
{
    private float sunValue = 50f;

    public float additionalCost;
    public float chargeRate;
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public float currentEnergy { get; set; }
    public float maxEnergy { get; set; }
    public bool solarCharged = false;
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

        if (Input.GetKey(KeyCode.Keypad8))
        {
            ChargeEnergy();
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            SolarCharge();
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            SolarRevert();
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

    public float ReceiveDamage (float damageValue)
    {
        currentHealth -= damageValue;
        healthBar.value = CalculateHealth();
        return currentHealth;
    }
 
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
