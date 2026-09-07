using System.Collections;
using UnityEngine;

public class DialogoTrigger : MonoBehaviour
{
    [SerializeField] private DialogoData dialogoData;
    private bool yaPase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!yaPase)
        { 
            if (DialogoManager.Instance == null)
            {
                Debug.Log("El Dialogo Manager no está instanciado!!");
                return;
            }

            if (dialogoData != null)
            {
                DialogoManager.Instance.IniciarDialogo(dialogoData, gameObject.transform);
            }

            yaPase = true;
        }
    }
}
