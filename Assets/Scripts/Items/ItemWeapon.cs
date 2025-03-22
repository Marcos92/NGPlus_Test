using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 2)]
public class ItemWeapon : Item
{
    [SerializeField] private int damage;

    public override void Use()
    {

    }
}
