using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] public string nombre;
    [SerializeField] DialogoData dialogo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>().hasCamera)
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

    IEnumerator EsperaCarga()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(nombre);
        SceneManager.UnloadSceneAsync("PantallaCarga");
    }
}
