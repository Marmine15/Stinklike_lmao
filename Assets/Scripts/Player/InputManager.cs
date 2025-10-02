using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;

    public float Horizontal;
    public Vector2 MousePosition;

    public bool Attack;

    private void Awake()
    {
        _inputSystem = new InputSystem_Actions();
    }

    private void Update()
    {
        Horizontal = _inputSystem.Player.Move.ReadValue<Vector2>().x;
        Attack = _inputSystem.Player.Attack.WasPressedThisFrame();
        MousePosition = _inputSystem.Player.Look.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
    }

    private void OnDisable()
    {
        _inputSystem.Disable();
    }
}
