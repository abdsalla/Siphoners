using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{

    public PlayerAttack playerAttack;
    public GameObject player;

    // Grab the player and its PlayerAttack script
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        playerAttack = player.GetComponent<PlayerAttack>();

    }

    // Destroy the hitbox after a second
    void Update()
    {

        Destroy(this.gameObject, 1);

    }

    // OnTriggerStay to see if anything is inside.
    void OnTriggerStay(Collider other)
    {
        
        // If the player is inside, it doesn't do anyhting.
        if (other.tag == "Player")
        {
            // Do nothing
        }
        // If an enemy is inside, then take away health from the enemy and destroy the hitbox.
        else if (other.tag == "Enemy")
        {
            Debug.Log("Hurt that enemy!");
            other.gameObject.GetComponent<EnemyAi>().health -= playerAttack.playerDamage;

            if(other.gameObject.GetComponent<EnemyAi>().health <= 0)
            {
                Destroy(other.gameObject);
            } else
            {
                // Do nothing
            }

            Destroy(this.gameObject);
        }
        
    }

}
