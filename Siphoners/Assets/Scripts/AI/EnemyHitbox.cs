using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{

    public EnemyAi enemyDamage;

    // Start is called before the first frame update
    void Start()
    {

        enemyDamage = gameObject.GetComponentInParent<EnemyAi>();

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 2);
    }

    // OnTriggerStay to see if anything is inside.
    void OnTriggerStay(Collider other)
    {
        // If an enemy is inside, it doesn't do anyhting.
        if (other.tag == "Enemy")
        {
            // Do nothing
        }
        // If the player is inside, then take away health from the player and destroy the hitbox.
        else if (other.tag == "Player")
        {
            Debug.Log("Hurt that player!");
            other.gameObject.GetComponent<Health>().currentHealth -= enemyDamage.damage;
            Destroy(this.gameObject);
        }

    }

}
