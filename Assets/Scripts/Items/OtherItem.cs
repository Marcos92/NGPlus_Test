using UnityEngine;

[CreateAssetMenu(fileName = "Other", menuName = "ScriptableObjects/Other", order = 3)]
public class OtherItem : Item
{
    void Awake()
    {
        type = ItemType.OTHER;
    }

    public override void Use()
    {

    }
}