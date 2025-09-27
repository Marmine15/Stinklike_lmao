using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private InputManager _inputSystem;
    private Rigidbody2D _rigidbody2D;

    public Camera cam;

    private void Start()
    {
        _inputSystem = GetComponent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //var zRotation = Mathf.Atan2(_inputSystem.MousePosition.y, _inputSystem.MousePosition.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, zRotation - 90f); 
        PointToMouse();
    }

    void PointToMouse()
    { 
        Vector2 mousePos = cam.ScreenToWorldPoint(_inputSystem.MousePosition);
        
        Vector2 lookDir = mousePos - _rigidbody2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _rigidbody2D.rotation = angle;
    }
}
