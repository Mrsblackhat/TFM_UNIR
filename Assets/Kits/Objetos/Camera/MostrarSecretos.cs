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
