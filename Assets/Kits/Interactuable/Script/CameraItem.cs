using UnityEngine;

public class CameraItem : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject tutorialMessage;

    public void Interactuar(GameObject playerGameObject)
    {
        playerGameObject.GetComponent<PlayerController>().hasCamera = true;
        playerGameObject.GetComponent<PlayerController>().ActivateBattery();

        tutorialMessage.GetComponent<TutorialEnd>().MostrarCamara();

        Destroy(gameObject);
    }
}
