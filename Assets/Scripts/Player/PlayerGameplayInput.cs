using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerGameplayInput : MonoBehaviour
{
    private InputActionAsset actionAsset;
    private InputActionMap actionMap;

    public Vector2 Move => actionMap.FindAction("Move").ReadValue<Vector2>().normalized;

    [HideInInspector] public static UnityEvent OnAttackDown = new();
    [HideInInspector] public static UnityEvent OnMenuDown = new();

    void Start()
    {
        actionAsset = GetComponent<PlayerInput>().actions;
        actionMap = actionAsset.FindActionMap("Gameplay");

        actionMap.FindAction("Attack").performed += ctx => OnAttackDown.Invoke();
        actionMap.FindAction("Menu").performed += ctx => OnMenuDown.Invoke();
    }
}