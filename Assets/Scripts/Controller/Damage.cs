using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform tf;
    public Transform targetTf;

    public float distanceToDealDamage;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCloseEnough())
        {
            // Deal Damage
            dealDamage();
        }
    }

    private bool isCloseEnough()
    {
        if (Vector3.Distance(tf.position, targetTf.position) < distanceToDealDamage)
        {
            return true;
        }
        return false;
    }

    public void dealDamage()
    {
        // target.takeDamage(damageToDeal);
    }

    public void takeDamage(float damageToTake)
    {
        // currentHealth -= damageToTake;
    }
}
