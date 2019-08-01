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
    private ParticleSystem lightParticle;
    private Light lightComp;
    private Energy energyRef;


    void Start()
    {
    lightComp = lightGameObject.GetComponent<Light>();
    //lightComp.type = LightType.Spot;
    //lightComp.lightmapBakeType = LightmapBakeType.Realtime;
    energyRef = playerReference.GetComponent<Energy>();
    lightParticle = lightGameObject.GetComponent<ParticleSystem>();
    var lights = lightParticle.lights;
    //lightComp.color = Color.yellow;
    isOn = true;
    
    }

    void Update()
    {
       // Debug.Log("energyRef.solarCharged = " + energyRef.solarCharged);
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
        var lights = lightParticle.lights;
        lights.enabled = true;
        isOn = true;
    }

    void TurnOff()
    {
        var lights = lightParticle.lights;
        lights.enabled = false;
        isOn = false;
    }

    void SolarCharged()
    {
        Debug.Log("Solar Charged");
       // lightComp.intensity = 7;

    }

    void SolarRevert()
    {
       // lightComp.intensity = 1;
    }

}
