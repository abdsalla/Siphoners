using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Analytics;

public class Inventory : MonoBehaviour
{
    public const int MAX_INVENTORY = 20;
    public Item[] items;


    // Start is called before the first frame update
    void Start()
    {
        items = new Item[MAX_INVENTORY];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                return true;
            }
        }
        return false;
    }

}
