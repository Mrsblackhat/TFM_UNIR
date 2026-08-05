using UnityEngine;
using UnityEngine.AI;

public class PauseSecrets : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Mostrar()
    {
        spriteRenderer.enabled = true;
    }

    public void Ocultar()
    {
        spriteRenderer.enabled = false;
    }
}
