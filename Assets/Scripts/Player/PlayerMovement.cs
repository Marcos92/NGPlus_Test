using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerGameplayInput input;
    [SerializeField] private float speed;

    void Awake()
    {
        input = GetComponent<PlayerGameplayInput>();
    }

    void FixedUpdate()
    {
        Vector2 direction = input.Move;
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
