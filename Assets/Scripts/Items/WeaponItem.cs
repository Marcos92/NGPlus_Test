using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 2)]
public class WeaponItem : Item
{
    [SerializeField] private Weapon weapon;
    public Weapon Weapon => weapon;

    void Awake()
    {
        type = ItemType.WEAPON;
    }

    public override void Use()
    {

    }
}