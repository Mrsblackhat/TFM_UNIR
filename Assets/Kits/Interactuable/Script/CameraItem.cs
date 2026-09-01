using UnityEngine;

public class CameraItem : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject tutorialMessage;

    public void Interactuar(GameObject playerGameObject)
    {
        playerGameObject.GetComponent<PlayerController>().hasCamera = true;
        playerGameObject.GetComponent<PlayerController>().ActivateBattery();

        tutorialMessage.GetComponent<Canvas>().enabled = true;

        Destroy(gameObject);
    }
}
