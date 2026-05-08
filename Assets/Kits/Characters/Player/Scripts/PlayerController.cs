using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 5f;

    [Header("Input")]
    [SerializeField] InputActionReference inputReference;

    Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputReference.action.Enable();
        inputReference.action.started += OnMove;
        inputReference.action.performed += OnMove;
        inputReference.action.canceled += OnMove;
    }

    private void Update()
    {
        rb2D.position += moveDirection * speed * Time.deltaTime;

        Debug.Log(moveDirection);
    }

    private void OnDisable()
    {
        inputReference.action.Disable();
        inputReference.action.started -= OnMove;
        inputReference.action.performed -= OnMove;
        inputReference.action.canceled -= OnMove;
    }

    Vector2 moveDirection = Vector2.zero;
    private void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }
}
