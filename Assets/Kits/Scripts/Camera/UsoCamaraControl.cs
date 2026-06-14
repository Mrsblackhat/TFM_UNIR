using UnityEngine;
using UnityEngine.InputSystem;

public class UsoCamaraControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D Collider2D;

    public MonoBehaviour script;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Collider2D.enabled = false;
            script.enabled = false;
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
        else
        {
            Collider2D.enabled = true;
            script.enabled = true;
        }
    }
}
