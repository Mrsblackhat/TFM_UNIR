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
    [SerializeField] InputActionReference cameraInputReference;

    [Header("Interaction")]
    [SerializeField] private float radioDeteccion = 0.2f;
    [SerializeField] private float distanciaInteraccion = 0.4f;
    [SerializeField] private LayerMask queEsInteractuable;

    [Header("Animation")]
    [SerializeField] private Animator anim;
    [SerializeField] private float deadZone = 0.1f;

    private Rigidbody2D rb2D;

    private BateriaPlayer player;
    [SerializeField] private float danoPorSegundo = 1f; //Hay que ajustarlo
    private bool danarJugador = false;

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

        player = GetComponent<BateriaPlayer>();
    }

    private void OnEnable()
    {
        inputReference.action.Enable();

        interactInputReference.action.Enable();
        interactInputReference.action.performed += OnInteract;

        cameraInputReference.action.Enable();
        cameraInputReference.action.performed += OnCamera;
        cameraInputReference.action.canceled += OnCamera;
    }

    private void OnDisable()
    {
        inputReference.action.Disable();

        interactInputReference.action.performed -= OnInteract;
        interactInputReference.action.Disable();

        cameraInputReference.action.performed -= OnCamera;
        cameraInputReference.action.canceled -= OnCamera;
        cameraInputReference.action.Disable();
    }


    private void Update()
    {
        moveDirection = inputReference.action.ReadValue<Vector2>();

        if (moveDirection.sqrMagnitude < deadZone * deadZone)
        {
            moveDirection = Vector2.zero;
        }

        if (!canMove || DialogoManager.BloqueaJugador)
        {
            moveDirection = Vector2.zero;
            rb2D.linearVelocity = Vector2.zero;
            ActualizarAnimacion(Vector2.zero);
            return;
        }

        rb2D.position += moveDirection * speed * Time.deltaTime;

        ActualizarAnimacion(moveDirection);

        if(danarJugador)
        {
            player.DanarJugador(danoPorSegundo * Time.deltaTime);
        }
    }


    private void OnCamera(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            danarJugador = true;
        }
        else
        {
            danarJugador = false;
        }
    }


    private void OnInteract(InputAction.CallbackContext context) //TODO LO INTERACTUABLE TIENE QUE ESTAR EN EL LAYER INTERACTUABLE
    {
        if (DialogoManager.HayDialogoAbierto)
        {
            DialogoManager.Instance.SiguienteFrase();
            return;
        }

        Vector2 puntoInteraccion = (Vector2)transform.position + lastDirection.normalized * distanciaInteraccion;

        Collider2D collider = Physics2D.OverlapCircle(puntoInteraccion, radioDeteccion, queEsInteractuable);
        //Debug.Log("Choco con" + collider.name);

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
