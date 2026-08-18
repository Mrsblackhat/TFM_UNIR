using UnityEngine;
using UnityEngine.SceneManagement;

public class des_aparecer : MonoBehaviour
{
    [SerializeField] GameObject puerta;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            Debug.Log("Player ha entrado. Llave: " + player.hasLlave);

            puerta.SetActive(player.hasLlave);
        }
    }
}
