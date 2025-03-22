using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string title;
    public string description;
    public Sprite sprite;

    public abstract void Use();
}