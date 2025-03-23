using System;
using UnityEngine;

[Serializable]
public abstract class Item : ScriptableObject
{
    public string title;
    public string description;
    public Sprite sprite;
    public ItemType type;

    public abstract void Use();
}

public enum ItemType
{
    ALL,
    CONSUMABLE,
    WEAPON,
    OTHER
}