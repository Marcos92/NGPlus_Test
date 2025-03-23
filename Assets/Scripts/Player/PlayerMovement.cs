using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerGameplayInput input;
    [SerializeField] private float speed;
    private bool canMove = true;

    void Awake()
    {
        input = GetComponent<PlayerGameplayInput>();
        PlayerAttack.OnAttackStart.AddListener(() => canMove = false);
        PlayerAttack.OnAttackEnd.AddListener(() => canMove = true);
    }

    void FixedUpdate()
    {
        Vector2 direction = input.Move;
        transform.Translate((canMove ? speed : 0) * Time.deltaTime * direction);
    }
}