using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    [Header("Items pickup")]
    [SerializeField] Transform pickUpPoint;
    Item currentItem;

    [Header("Animation")]
    [SerializeField] private Animator anim;
    [SerializeField] private float deadZone = 0.1f;

    [Header("Batería")]
    public bool hasCamera = false;
    private BateriaPlayer player;
    [SerializeField] private float danoPorSegundo = 1f; //Hay que ajustarlo
    private bool danarJugador = false;
    [SerializeField] private Image camara;

    [Header("LlaveBuhardilla")]
    public bool hasLlave = false;

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

        player = GetComponent<BateriaPlayer>();

        camara.gameObject.SetActive(false);
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

        if(hasLlave)
        { Debug.Log("tengo la llave"); }
    }

    private void OnCamera(InputAction.CallbackContext context)
    {
        if (hasCamera)
        { 
            if(context.performed)
            {
                camara.gameObject.SetActive(true);
                danarJugador = true;
                AvisarAfectados(true);

                PauseEnemy[] enemigos = FindObjectsOfType<PauseEnemy>();
                foreach (PauseEnemy enemigo in enemigos)
                {
                    enemigo.pause();
                }

                PauseSecrets[] secretos = FindObjectsOfType<PauseSecrets>();
                foreach (PauseSecrets secret in secretos)
                {
                    secret.Mostrar();
                }
            }
            else
            {
                camara.gameObject.SetActive(false);
                danarJugador = false;
                AvisarAfectados(false);

                PauseEnemy[] enemigos = FindObjectsOfType<PauseEnemy>();
                foreach (PauseEnemy enemigo in enemigos)
                {
                    enemigo.move();
                }

                PauseSecrets[] secretos = FindObjectsOfType<PauseSecrets>();
                foreach (PauseSecrets secret in secretos)
                {
                    secret.Ocultar();
                }
            }
        }
    }
    
    private void AvisarAfectados(bool camaraActiva)
    {
        MonoBehaviour[] scripts = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include,FindObjectsSortMode.None);
        foreach (MonoBehaviour script in scripts)
        {
            if (script is IAfectadoPorCamara afectado)
            {
                afectado.CambiarEstadoCamara(camaraActiva);
            }
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

        Collider2D[] colliders = Physics2D.OverlapCircleAll(puntoInteraccion, radioDeteccion, queEsInteractuable);
        float minDistance = Mathf.Infinity;
        Interactuable nearestInteractuable = null;

        // Se interactuara con el mas cercano
        foreach (Collider2D col in colliders)
        {
            Interactuable interactuable = col.GetComponent<Interactuable>();

            if (interactuable != null)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, col.transform.position);

                if (distanceToPlayer < minDistance)
                {
                    minDistance = distanceToPlayer;
                    nearestInteractuable = interactuable;
                }
            }
        }

        if (nearestInteractuable != null)
        {
            nearestInteractuable.Interactuar(gameObject);
        }
    }

    public void PickUpItem(Item newItem)
    {
        if (currentItem == null)
        {
            currentItem = newItem;
            currentItem.SetParent(pickUpPoint);
        }
    }

    public void DropItem()
    {
        if (currentItem != null)
        {
            currentItem.DropDown();
            currentItem = null;
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

    public void RestartBattery()
    {
        player.Reset();
    }

    private void OnDrawGizmos()
    {
        Vector2 direccion = (Vector2)transform.position + lastDirection.normalized * distanciaInteraccion;

        Gizmos.DrawSphere(direccion, radioDeteccion);
    }
}
