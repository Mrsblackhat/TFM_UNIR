using System;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    private bool estaEscondido;
    public bool EstaEscondido => estaEscondido;

    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;
    private AudioSource audioSource;

    private Vector3 posInicial;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponentInChildren<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponentInChildren<AudioSource>();
    }


    public void EntrarArmario(Armario armario)
    {
        estaEscondido = true;

        posInicial = rb.position;
        rb.position = armario.PosEscondido;

        if (playerController != null)
        {
            playerController.SetCanMove(false);
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = false;
        }

        if (audioSource != null)
        {
            audioSource.enabled = false;
        }
    }

    public void SalirArmario()
    {
        rb.position = posInicial;

        estaEscondido = false;

        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = true;
        }

        if (playerController != null)
        {
            playerController.SetCanMove(true);
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        if (audioSource != null)
        {
            audioSource.enabled = true;
        }
    }
}
