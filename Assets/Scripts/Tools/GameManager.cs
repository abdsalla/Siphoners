using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public IUVSensor sensor;


    private Energy eRef;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        sensor = GetComponent<IUVSensor>();

    }
    void Update()
    {
        if (eRef.healthBar.value <= 0 && eRef.currentHealth <= 0)
        {
            eRef.healthBar.value = 0;
            eRef.currentHealth = 0;
            OnDeath();
        }
        sensor.GetUVValue();
    }

    private void OnDeath()
    {
        Destroy(eRef.gameObject);
    }


}
