using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialEnd : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<Canvas>().enabled)
        {
            if (Keyboard.current.fKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
