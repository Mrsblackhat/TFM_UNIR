using UnityEngine;

public class DialogoObjetos : MonoBehaviour, Interactuable
{
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
}
