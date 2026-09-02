using UnityEngine;

public class ArmarioFalso : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject canvas;
    [SerializeField] private float dano;
    public void Interactuar(GameObject playerGameObject)
    {
        BateriaPlayer vida = playerGameObject.GetComponent<BateriaPlayer>();

        if (vida != null)
        { 
            vida.DanarJugador(dano);
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
