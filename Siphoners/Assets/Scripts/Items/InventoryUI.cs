using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    InventoryManager inventory;

    InventorySlot[] slots;

    void Start()
    {
        inventory = InventoryManager.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].DisplayItem(inventory.items[i]);
            } else
            {
                // Eventual Clear Function
            }
        }
    }
}
