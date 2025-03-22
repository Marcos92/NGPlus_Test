using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerGameplayInput : MonoBehaviour
{
    private InputActionAsset actionAsset;
    private InputActionMap actionMap;

    public Vector2 Move => actionMap.FindAction("Move").ReadValue<Vector2>().normalized;

    private readonly UnityEvent onAttackDown = new();
    public UnityEvent OnAttackDown => onAttackDown;

    private readonly UnityEvent onInteractDown = new();
    public UnityEvent OnInteractDown => onInteractDown;

    private static readonly UnityEvent onMenuDown = new();
    public static UnityEvent OnMenuDown => onMenuDown;

    void Start()
    {
        actionAsset = GetComponent<PlayerInput>().actions;
        actionMap = actionAsset.FindActionMap("Gameplay");

        actionMap.FindAction("Attack").performed += ctx => onAttackDown.Invoke();
        actionMap.FindAction("Interact").performed += ctx => onInteractDown.Invoke();
        actionMap.FindAction("Menu").performed += ctx => onMenuDown.Invoke();
    }
}