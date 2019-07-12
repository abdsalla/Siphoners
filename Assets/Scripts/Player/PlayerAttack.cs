using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Energy energyRef;

    public GameObject enemyRef;
    public float playerDamage;
    public float chargeAttackValue;

    void Awake()
    {
        energyRef = GetComponent<Energy>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {

            chargeAttackValue = energyRef.ReceiveDamage(playerDamage);

        }
    }
}
