using TMPro;
using UnityEngine;

public class EquipmentSlot : MonoBehaviour
{
    private ItemSlot slot;
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text attackLabel;

    void Awake()
    {
        InventoryEvent.OnItemDrop.AddListener(UpdateEquipment);
    }

    void Start()
    {
        slot = GetComponentInChildren<ItemSlot>();
        SetItem(InventoryManager.Instance.EquippedItem);
    }

    public void SetItem(Item item)
    {
        WeaponItem weapon = item as WeaponItem;
        slot.SetItem(weapon);
        SetText(weapon);
    }

    private void SetText(WeaponItem weapon)
    {
        if (weapon != null)
        {
            nameLabel.text = weapon.title;
            attackLabel.text = "ATK: " + weapon.damage;
        }
        else
        {
            nameLabel.text = "(NO WEAPON)";
            attackLabel.text = "ATK: " + 0;
        }
    }

    private void UpdateEquipment()
    {
        WeaponItem weapon = (WeaponItem)slot.Item;
        InventoryManager.Instance.UpdateEquippedItem(weapon);
        SaveSystem.Instance.Save();
        SetText(weapon);
    }
}
