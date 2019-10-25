using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Item : PickUp
{
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnPickUp(PlayerMovement player)
    {
        InventoryManager.instance.Add(item);
        Destroy(gameObject);
        //player.GetComponent<Inventory>().AddItem(item);
        //base.OnPickUp(player);
    }
    
}
