using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 2)]
public class WeaponItem : Item
{
    public int damage;

    void Awake()
    {
        type = ItemType.WEAPON;
    }

    public override void Use()
    {

    }
}
