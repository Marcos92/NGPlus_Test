using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "ScriptableObjects/Consumable", order = 1)]
public class ItemConsumable : Item
{
    [SerializeField] private int health;

    public override void Use()
    {

    }
}