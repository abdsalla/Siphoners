using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public const int MAX_INVENTORY = 20;
    public Item[] items;
    public Item testItem;
    public GameObject inventoryMenu;

    void Start()
    {
        items = new Item[MAX_INVENTORY];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && inventoryMenu.activeSelf == false)
        {
            inventoryMenu.SetActive(true);
            inventoryMenu.transform.Find("Inventory").gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I) && inventoryMenu.activeSelf == true)
        {
            inventoryMenu.SetActive(false);
            inventoryMenu.transform.Find("Inventory").gameObject.SetActive(true);
        }
        
        inventoryMenu.GetComponentInChildren<Button>().onClick.AddListener(UseItem);  
    }

    public void AddItem()
    {
        Debug.Log("Function Start");

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = testItem;
                Debug.Log("Added Item");
                break;
            }
        }
    }
 
    public void UseItem()
    {
        Item itemToUse;
        itemToUse = testItem;
        itemToUse.OnUseEffect();
    }
}