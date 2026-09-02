using System;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    private bool estaEscondido;
    public bool EstaEscondido => estaEscondido;

    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }


    public void EntrarArmario(Armario armario)
    {
        estaEscondido = true;

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
    }

    public void SalirArmario()
    {
        estaEscondido = false;

        if (playerController != null)
        {
            playerController.SetCanMove(true);
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = true;
        }
    }
}
