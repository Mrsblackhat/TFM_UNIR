using UnityEngine;

public class DialogoObjetos : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject canvas;
    [SerializeField] private DialogoData dialogoData;

    public void Interactuar(GameObject playerGameObject)
    {
        if (DialogoManager.Instance == null)
        {
            Debug.Log("El Dialogo Manager no está instanciado!!");
            return;
        }

        DialogoManager.Instance.IniciarDialogo(dialogoData, gameObject.transform);
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
