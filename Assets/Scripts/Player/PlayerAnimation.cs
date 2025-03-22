using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerGameplayInput input;
    private Animator animator;
    private Vector2 direction;

    void Awake()
    {
        input = GetComponent<PlayerGameplayInput>();
        animator = GetComponent<Animator>();
        direction = new(0, -1);
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (input.Move.magnitude > 0)
        {
            direction = input.Move;
        }

        animator.SetBool("IsMoving", input.Move.magnitude > 0);
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
    }
}