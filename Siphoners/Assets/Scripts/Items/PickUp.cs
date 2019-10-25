using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();
        if (player)
        {
            OnPickUp(player);
        }
    }

    protected virtual void OnPickUp(PlayerMovement player)
    {
        Destroy(gameObject);
    }

}
