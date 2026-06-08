using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 5f;

    [Header("Input")]
    [SerializeField] InputActionReference inputReference;
    [SerializeField] InputActionReference interactInputReference;

    [Header("Interaction")]
    [SerializeField] private float radioDeteccion = 0.4f;
    [SerializeField] private float distanciaInteraccion = 0.8f;
    [SerializeField] private LayerMask queEsInteractuable;

    Rigidbody2D rb2D;

    private Vector2 moveDirection = Vector2.zero;
    private Vector2 direccionMirada = Vector2.down;

    private bool canMove = true;

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

        interactInputReference.action.Enable();
        interactInputReference.action.performed += OnInteract;
    }

    private void Update()
    {
        if (!canMove) { return; }

        rb2D.position += moveDirection * speed * Time.deltaTime;

        Debug.Log(moveDirection);
    }

    private void OnDisable()
    {
        inputReference.action.Disable();
        inputReference.action.started -= OnMove;
        inputReference.action.performed -= OnMove;
        inputReference.action.canceled -= OnMove;

        interactInputReference.action.Disable();
        interactInputReference.action.performed -= OnInteract;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();

        if (moveDirection != Vector2.zero)
        {
            direccionMirada = moveDirection.normalized;
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Vector2 puntoInteraccion = (Vector2)transform.position + direccionMirada.normalized * distanciaInteraccion;

        Collider2D collider = Physics2D.OverlapCircle(puntoInteraccion, radioDeteccion, queEsInteractuable);

        if(collider != null)
        {
            Interactuable interactuable = collider.GetComponent<Interactuable>();

            if(interactuable != null)
            {
                interactuable.Interactuar();
            }
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;

        if (!canMove)
        {
            moveDirection = Vector2.zero;
            rb2D.linearVelocity = Vector2.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 direccion = (Vector2)transform.position + direccionMirada.normalized * distanciaInteraccion;

        Gizmos.DrawSphere(direccion, radioDeteccion);
    }
}
