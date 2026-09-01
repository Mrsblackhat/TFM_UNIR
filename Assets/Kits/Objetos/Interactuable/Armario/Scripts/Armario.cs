using UnityEngine;

public class Armario : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject canvas;

    public void Interactuar(GameObject playerGameObject)
    {
        PlayerHide playerHide = playerGameObject.GetComponent<PlayerHide>();

        if (playerHide != null)
        {
            if (playerHide.EstaEscondido)
            {
                playerHide.SalirArmario();
            }
            else
            {
                playerHide.EntrarArmario(this);
            }
        }
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
