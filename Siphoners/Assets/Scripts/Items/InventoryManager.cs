using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    #region Singleton

    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public void Add (Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("No space!");
            return;
        }
        items.Add(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Use (Item item)
    {
        
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

}
