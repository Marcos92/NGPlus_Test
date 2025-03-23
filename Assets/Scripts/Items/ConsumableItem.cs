using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "ScriptableObjects/Consumable", order = 1)]
public class ConsumableItem : Item
{
    [SerializeField] private int health;

    void Awake()
    {
        type = ItemType.CONSUMABLE;
    }

    public override void Use()
    {

    }
}