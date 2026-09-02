using UnityEngine;

public class BrokenMirror : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject finalTrigger;
    [SerializeField] ParticleSystem particles;
    [SerializeField] GameObject canvas;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Interactuar(GameObject playerGameObject)
    {
        anim.SetTrigger("Break");
        particles.Play();
    }

    public void ActivateWinGameObject()
    {
        finalTrigger.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
