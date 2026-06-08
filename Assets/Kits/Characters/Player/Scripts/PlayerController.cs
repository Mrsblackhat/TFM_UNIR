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
    [SerializeField] private float radioDeteccion = 0.2f;
    [SerializeField] private float distanciaInteraccion = 0.4f;
    [SerializeField] private LayerMask queEsInteractuable;

    [Header("Animation")]
    [SerializeField] private Animator anim;
    [SerializeField] private float deadZone = 0.1f;

    private Rigidbody2D rb2D;

    private Vector2 moveDirection = Vector2.zero;
    private Vector2 lastDirection = Vector2.down; 

    private bool canMove = true;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    private void OnEnable()
    {
        inputReference.action.Enable();

        interactInputReference.action.Enable();
        interactInputReference.action.performed += OnInteract;
    }

    private void OnDisable()
    {
        inputReference.action.Disable();

        interactInputReference.action.performed -= OnInteract;
        interactInputReference.action.Disable();
    }

    private void Update()
    {
        moveDirection = inputReference.action.ReadValue<Vector2>();

        if (moveDirection.sqrMagnitude < deadZone * deadZone)
        {
            moveDirection = Vector2.zero;
        }


        if (!canMove) 
        {
            ActualizarAnimacion(Vector2.zero); 
            return; 
        }

        rb2D.position += moveDirection * speed * Time.deltaTime;

        ActualizarAnimacion(moveDirection);
    }


    private void OnInteract(InputAction.CallbackContext context)
    {
        Vector2 puntoInteraccion = (Vector2)transform.position + lastDirection.normalized * distanciaInteraccion;

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
            ActualizarAnimacion(Vector2.zero);
        }
    }

    private void ActualizarAnimacion(Vector2 direccion)
    {
        bool moviendose = direccion.sqrMagnitude > deadZone * deadZone;

        Debug.Log("direccion: " + direccion + " | moviendose: " + moviendose);

        anim.SetBool("moving", moviendose);

        if (moviendose)
        {
            lastDirection.x = Mathf.Round(direccion.x);
            lastDirection.y = Mathf.Round(direccion.y);
        }

        anim.SetFloat("x", lastDirection.x);
        anim.SetFloat("y", lastDirection.y);
    }

    private void OnDrawGizmos()
    {
        Vector2 direccion = (Vector2)transform.position + lastDirection.normalized * distanciaInteraccion;

        Gizmos.DrawSphere(direccion, radioDeteccion);
    }
}
