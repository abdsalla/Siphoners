using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    public IUVSensor sensor;
    public GameObject player;
    public GameObject currentPlayer;
    public Camera main;
    public CameraFollow cameraFollow;
    public GameObject spawn;

    private Energy eRef;
    private static GameManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        sensor = GetComponent<IUVSensor>();
        cameraFollow = main.GetComponent<CameraFollow>();
    }

    void Start()
    {
        currentPlayer = Instantiate(player, spawn.transform.position, spawn.transform.rotation).GetComponentInChildren<PlayerMovement>().gameObject;
        eRef = instance.currentPlayer.GetComponent<Energy>();    

    }

    void Update()
    {
        if (currentPlayer == null)
        {
            currentPlayer = Instantiate(player, spawn.transform.position, spawn.transform.rotation).GetComponentInChildren<PlayerMovement>().gameObject;
            Debug.Log("Player Instantiated");
            cameraFollow.target = currentPlayer.GetComponent<HumanData>().viewPoint;
        }

        if (eRef.healthBar.fillAmount <= 0 && eRef.currentHealth <= 0)
        {
            eRef.healthBar.fillAmount = 0;
            eRef.currentHealth = 0;
        }
        sensor.GetUVValue();

        if (spawn == null)
        {
            spawn = GameObject.FindWithTag("Spawn");
        }
    }
}