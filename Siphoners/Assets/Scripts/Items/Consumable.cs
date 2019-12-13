using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    ItemType thisItemType = ItemType.Consumable;
    
    public override void OnUseEffect()
    {
        throw new NotImplementedException();
    }
}