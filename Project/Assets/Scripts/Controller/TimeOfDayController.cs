using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayController : MonoBehaviour
{
    [SerializeField] private Light sun;
    [SerializeField] private float secondsInFullDay = 120f;
    [Range(0, 1)] [SerializeField] private float currentTimeOfDay = 0;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
  
    void Start()
    {
        sunInitialIntensity = sun.intensity;
    }

    
    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }


    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;

        if (currentTimeOfDay <= .23f || currentTimeOfDay >= .75f)
        {
            intensityMultiplier = 0;
        }

        else if (currentTimeOfDay <= .25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - .23f) * (1 / .02f));
        }

        else if (currentTimeOfDay >= .73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 -((currentTimeOfDay - .73f) * (1 / .02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
