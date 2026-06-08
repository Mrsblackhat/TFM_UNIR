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
    public Animator anim;

    Vector2 ActualDirection = Vector2.zero;
    Vector2 lastDirection = Vector2.down; 

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
    }

    private void Update()
    {
        ActualDirection = inputReference.action.ReadValue<Vector2>();

        rb2D.position += ActualDirection * speed * Time.deltaTime;

        bool moviendose = (ActualDirection != Vector2.zero);

        anim.SetBool("moving", moviendose);

        if (moviendose)
        {
            lastDirection.x = Mathf.Round(ActualDirection.x);
            lastDirection.y = Mathf.Round(ActualDirection.y);
        }

        anim.SetFloat("x", lastDirection.x);
        anim.SetFloat("y", lastDirection.y);
    }

    private void OnDisable()
    {
        inputReference.action.Disable();
    }
}
