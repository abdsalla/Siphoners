using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Energy energyRef;

    //public GameObject enemyRef;
    public int playerDamage;
    //public float chargeAttackValue;
    public int attackTime;

    private ControllerAI enemy;

    public GameObject attackBox;

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

    // When called, it instaniates an attack box in front of the player.
    void Attack()
    {

        Instantiate(attackBox, attackPoint);

        Debug.Log("Set active to attack");

    }
}
