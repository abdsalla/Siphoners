using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Energy energyRef;

    public int playerDamage;
    public int attackTime;

    private ControllerAI enemy;

    public Item weapon;

    public Transform attackPoint;

    void Awake()
    {
        energyRef = GetComponent<Energy>();
    }

    // If you press down K, then it calls the Attack function.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Pressed K to attack");
            Attack();
        }
    }

    // When called, it instantiates an attack box in front of the player.
    void Attack()
    {
        energyRef.currentEnergy -= playerDamage;
        Instantiate(weapon.body, attackPoint);
    }
}