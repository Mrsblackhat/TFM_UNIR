using UnityEngine;

public class CameraItem : MonoBehaviour, Interactuable
{
    public void Interactuar(GameObject playerGameObject)
    {
        playerGameObject.GetComponent<PlayerController>().hasCamera = true;
        Destroy(gameObject);
    }
}
