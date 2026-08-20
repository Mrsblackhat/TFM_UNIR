using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] int idSpawnPoint;
    [SerializeField] protected string nombre;
    [SerializeField] DialogoData dialogo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            PuedeCambiarEscena(player);

            if (canChange)
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync("PantallaCarga", LoadSceneMode.Additive);
                StartCoroutine(EsperaCarga());
            }
            else
            {
                if (DialogoManager.Instance == null) return;

                if (dialogo != null)
                {
                    DialogoManager.Instance.IniciarDialogo(dialogo, gameObject.transform);
                }
            }
        }
    }

    protected bool canChange = true;
    protected virtual void PuedeCambiarEscena(PlayerController player) { }

    IEnumerator EsperaCarga()
    {
        yield return new WaitForSeconds(0.5f);

        if (SpawnController.instance != null)
        {
            SpawnController.instance.idSpawn = idSpawnPoint;
        }

        SceneManager.LoadScene(nombre);
        SceneManager.UnloadSceneAsync("PantallaCarga");
    }

}
