using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    ItemType thisItemType = ItemType.Weapon;
    
    public override void OnUseEffect()
    {
        throw new NotImplementedException();
    }
}