using System;
using System.Collections.Generic;

[Serializable]
public class InventoryData
{
    public static readonly int maxInventorySize = 30;
    public List<Item> InventoryItems = new(maxInventorySize);
    public WeaponItem EquippedItem;
}