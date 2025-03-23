using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponHold;

    void Awake()
    {
        InventoryEvent.OnItemEquip.AddListener(EquipWeapon);
    }

    private void EquipWeapon(WeaponItem item)
    {
        if (weaponHold.childCount > 0)
        {
            Destroy(weaponHold.GetChild(0).gameObject);
        }

        Instantiate(item.Weapon, weaponHold);
    }
}
