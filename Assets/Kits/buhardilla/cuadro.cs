using UnityEngine;

public class cuadro : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject canvas;

    [SerializeField] private Animator animator;
    private bool yaInteractuo;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Interactuar(GameObject playerGameObject)
    {
        if (yaInteractuo) return;

        else
        {
            yaInteractuo = true;
            animator.SetTrigger("interactua"); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
