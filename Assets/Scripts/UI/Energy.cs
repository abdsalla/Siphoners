using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [Header("Energy Values")]
    private float sunValue = 50f;
    public float currentEnergy { get; set; }
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public float maxEnergy { get; set; }
    public float chargeRate;

    [Header("Extra Depletion")]
    public bool solarCharged = false;
    public float additionalCost;

    [Header("UI Elements")]
    public Image energyBar;
    public Image healthBar;


    void Start()
    {
        maxHealth = 100f;
        maxEnergy = 100f;
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        energyBar.fillAmount = maxEnergy;
        healthBar.fillAmount = maxHealth;
    }

    void Update()
    {
        //Testing Purposes

        /*if (Input.GetKeyDown(KeyCode.K))
        {
            UseEnergy(20);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Health: " + CalculateHealth());
            ReceiveDamage(20);
        }
*/
        if (Input.GetKeyDown(KeyCode.L))
        {

            HealDamage(20);
        }

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
        energyBar.fillAmount = CalculateEnergy();
    }

    //Called for player recharge
    public void ChargeEnergy ()
    {
        // If sunvalue is less than or equal to 20, yet more than 0 
        if (sunValue <= 20 && sunValue > 0)
        {
            //Set charge rate to .01
            chargeRate = .01f;
        }
        // If sunvalue is less than 60 yet greater than 20
        else if (sunValue <= 60 && sunValue > 20)
        {
            //Set charge rate to .25
            chargeRate = .25f;
        }
        // If sunvalue is less than or equal to 100 yet greater than 60
        else if (sunValue <= 100 && sunValue > 60)
        {
            //Set chargerate to .50
            chargeRate = .50f;
        }
        //If sunvalues is less than or equal to 0
        else
        {
            //Set charge rate to 0
            chargeRate = 0f;
        }
        //current energy changes due to charge rate
        currentEnergy += chargeRate;
        energyBar.fillAmount = CalculateEnergy();
    }


    // PLayer damage received
    public float ReceiveDamage (float damageValue)
    {
        currentHealth -= damageValue;
        //If the current health is less than 0, set it to zero so it doesn't go under
        if (currentHealth < 0) currentHealth = 0;
        healthBar.fillAmount = CalculateHealth();
        //if (currentHealth == 0) gameObject.SetActive(false);
    }
 
    //Player damage replenish
    public float HealDamage (float healValue)
    {
        currentHealth += healValue;
        //If current health is more than the max health set it to max so it doesn't go over
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.fillAmount = CalculateHealth();
        
    }

    //Health percentage is currenthealth divided by maxhealth
    public float CalculateHealth ()
    {
        return currentHealth / maxHealth;
    }

    //Energy percentage is currentenergy divided by maxenergy
    public float CalculateEnergy ()
    {
       return currentEnergy / maxEnergy;
    }

    //
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