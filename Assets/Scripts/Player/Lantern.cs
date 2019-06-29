using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using LightType = UnityEngine.LightType;

public class Lantern : MonoBehaviour
{
    public float energyDepletionRate;
    public GameObject lightGameObject;
    public GameObject playerReference;

    private bool isOn;
    private Light lightComp;
    private Energy energyRef;


    void Start()
    {
    lightComp = lightGameObject.AddComponent<Light>();
    lightComp.type = LightType.Spot;
    lightComp.lightmapBakeType = LightmapBakeType.Mixed;
    energyRef = playerReference.GetComponent<Energy>();
    lightComp.color = Color.yellow;
    isOn = true;
    
    }

    void Update()
    {
        Debug.Log("energyRef.solarCharged = " + energyRef.solarCharged);
        if (energyRef.energyBar.value > 0 && isOn == true)
        {
            energyRef.UseEnergy(energyDepletionRate);
        }
        else if (energyRef.energyBar.value <= 0 && isOn == true)
        {
            TurnOff();
        }
        else if (energyRef.energyBar.value > 0 && isOn == false)
        {
            TurnOn();
        }
        else if (energyRef.solarCharged)
        {
            Debug.Log("energyRef.solarCharged = " + energyRef.solarCharged);
            SolarCharged();
        }
    }

    void TurnOn()
    {
        lightComp.enabled = true;
        isOn = true;
    }

    void TurnOff()
    {
        lightComp.enabled = false;
        isOn = false;
    }

    void SolarCharged()
    {
        Debug.Log("Solar Charged");
        lightComp.intensity = 7;

    }

    void SolarRevert()
    {
        lightComp.intensity = 1;
    }

}
