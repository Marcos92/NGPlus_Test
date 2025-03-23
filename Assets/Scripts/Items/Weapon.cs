using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage => damage;
}