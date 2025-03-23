using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float duration;
    private float nextAttackTime;

    public static UnityEvent OnAttackStart = new();
    public static UnityEvent OnAttackEnd = new();

    void Awake()
    {
        nextAttackTime = Time.time;
        PlayerGameplayInput.OnAttackDown.AddListener(Attack);
    }

    private void Attack()
    {
        if (nextAttackTime <= Time.time)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        OnAttackStart.Invoke();
        yield return new WaitForSeconds(duration);
        OnAttackEnd.Invoke();
        nextAttackTime = Time.time + cooldown;
        yield return null;
    }
}
