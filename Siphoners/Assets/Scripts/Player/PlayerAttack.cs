using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Energy energyRef;

    public int playerDamage;
    //public float chargeAttackValue;
    public float attackTime = 1.5f;

    public float nextAttack;

    public Animator anim;

    private ControllerAI enemy;

    public Item weapon;

    public Transform attackPoint;

    void Awake()
    {
        energyRef = GetComponent<Energy>();
        
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // If you press down K, then it calls the Attack function.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && Time.time > nextAttack)
        {
            Debug.Log("Pressed K to attack");
            Attack();
            anim.Play("Melee");
            nextAttack = Time.time + attackTime;
        }
    }

    // When called, it instantiates an attack box in front of the player.
    void Attack()
    {
        energyRef.currentEnergy -= playerDamage;
        Instantiate(weapon.body, attackPoint);
    }
}