using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] public string nombre;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>().hasCamera)
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync("PantallaCarga", LoadSceneMode.Additive);

                StartCoroutine(EsperaCarga());
            }
        }
    }

    IEnumerator EsperaCarga()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.UnloadSceneAsync("PantallaCarga");
        SceneManager.LoadScene(nombre);

    }
}
