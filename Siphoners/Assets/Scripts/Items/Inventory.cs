using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Analytics;

public class Inventory : MonoBehaviour
{
    public const int MAX_INVENTORY = 20;
    public Item[] items;
    public Item testItem;
    public GameObject inventoryMenu;

    // Start is called before the first frame update
    void Start()
    {
        items = new Item[MAX_INVENTORY];

    }

    // Update is called once per frame
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

}
