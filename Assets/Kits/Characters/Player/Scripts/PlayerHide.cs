using System;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    public bool estaEscondido;

    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
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

        if (boxCollider != null)
        {
            boxCollider.enabled = false;
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

        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
    }
}
