using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElevatorTrigger : MonoBehaviour
{
    public bool canClickDoor;
    private Animator _animator;
    private bool animating;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        animating = false;
    }

    private void Update()
    {
        if (canClickDoor && Keyboard.current.wKey.wasPressedThisFrame)
        {
            print("load next level");
            
        }
        UpdateAnimation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canClickDoor = true;
        }
    }

    private void UpdateAnimation()
    {
        if (canClickDoor && Keyboard.current.wKey.wasPressedThisFrame)
        {
            print("load next level");
            _animator.Play("ElevatorIn");
            animating = true;
        }
        else if (!animating)       
        {
            _animator.Play("Elevator");
        }
    }
}
