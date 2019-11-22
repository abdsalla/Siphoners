using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : BaseItem 
{
    public override void OnUseEffect()
    {
        switch (type)
        {
            case ItemType.Weapon:
                break;
            case ItemType.Ammunition:
                break;
            case ItemType.Consumable:
                break;
            case ItemType.Key:
                break;
        }
    }
}