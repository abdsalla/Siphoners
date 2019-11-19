using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : ScriptableObject
{
    [Header("Qualification")]
    public string name;
    public string description;
    public enum ItemType { Default, Consumable, Weapon, Ammunition, Key}
    public ItemType type = ItemType.Default;

    [Header("Quantification")]
    public int amount;
    public int value;

    [Header("Visuals")]
    public GameObject body;
    public Sprite icon;

    public abstract void OnUseEffect();  
}