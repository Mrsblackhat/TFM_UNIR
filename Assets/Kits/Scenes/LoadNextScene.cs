using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] protected string nombre;
    [SerializeField] DialogoData dialogo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (PuedeCambiarEscena(player))
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync("PantallaCarga", LoadSceneMode.Additive);
                StartCoroutine(EsperaCarga());
            }
            else
            {
                if (DialogoManager.Instance == null) return;
                DialogoManager.Instance.IniciarDialogo(dialogo, gameObject.transform);
            }
        }
    }

    protected virtual bool PuedeCambiarEscena(PlayerController player)
    {
        return player.hasCamera;
    }

    IEnumerator EsperaCarga()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(nombre);
        SceneManager.UnloadSceneAsync("PantallaCarga");
    }

}
