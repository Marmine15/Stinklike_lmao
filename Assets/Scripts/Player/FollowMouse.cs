using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    private InputManager _inputSystem;
    private Rigidbody2D _rigidbody2D;
    public float offset;

    public Camera cam;

    private SpriteRenderer local, parent;
    private Transform parentTransform;
    
    private void Start()
    {
        _inputSystem = GetComponentInParent<InputManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        local = GetComponent<SpriteRenderer>();
        parent = transform.parent.GetComponent<SpriteRenderer>();
        parentTransform = GetComponentInParent<Transform>();
        if (cam == null)
        {
            cam = Camera.main;    
        }
    }

    private void Update()
    {
        /*Vector3 difference = cam.ScreenToWorldPoint(_inputSystem.MousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        PointToMouse();*/
        
        Vector2 dir = cam.ScreenToWorldPoint(_inputSystem.MousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;

        var mousePos = cam.ScreenToWorldPoint(_inputSystem.MousePosition);
        
        if (mousePos.x > parentTransform.position.x)
        {
            local.flipY = false;
            parent.flipX = false;
        }
        else
        {
            local.flipY = true;
            parent.flipX = true;
        }
    }

    void PointToMouse()
    { 
        Vector2 mousePos = cam.ScreenToWorldPoint(_inputSystem.MousePosition);
        
        Vector2 lookDir = mousePos - _rigidbody2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f,0f, angle);
    }
}
