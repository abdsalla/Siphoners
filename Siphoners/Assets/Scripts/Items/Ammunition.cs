using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : Item
{
    ItemType thisItemType = ItemType.Ammunition;
    
    public override void OnUseEffect()
    {
        amount -= 1;
    }
}