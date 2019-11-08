using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //Variables
    public string name;
    public string description;
    public int price;
    public enum ItemType { Default, Consumable, Weapon, Ammunition, Key}
    public ItemType type = ItemType.Default;
    public GameObject body;
    public Sprite icon;
}
