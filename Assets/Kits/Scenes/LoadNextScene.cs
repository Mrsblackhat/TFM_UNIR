using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] protected string nombre;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (PuedeCambiarEscena(player))
            {
                SceneManager.LoadScene(nombre);
            }
        }
    }
    protected virtual bool PuedeCambiarEscena(PlayerController player)
    {
        return player.hasCamera;
    }

}
