//No se si alguien lo lleva pero esto lo controla el playerController
//El Script "Secretos" debería hacer lo mismo - comprobarlo

using UnityEngine;
using UnityEngine.InputSystem;

public class MostrarSecretos : MonoBehaviour
{
    public GameObject secret;
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            secret.SetActive(true);
        }
        else
        {
            secret.SetActive(false);
        }
    }
}
