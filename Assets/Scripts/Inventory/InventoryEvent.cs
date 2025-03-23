using UnityEngine;
using UnityEngine.Events;

public class InventoryEvent
{
    [HideInInspector] public static UnityEvent OnItemAdd = new();
    [HideInInspector] public static UnityEvent OnItemDrop = new();
    [HideInInspector] public static UnityEvent OnItemConsume = new();
    [HideInInspector] public static UnityEvent<Item> OnItemSelect = new();
    [HideInInspector] public static UnityEvent OnItemUnselect = new();
    [HideInInspector] public static UnityEvent<WeaponItem> OnItemEquip = new();
}