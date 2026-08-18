using UnityEngine;

public class LlaveItem : MonoBehaviour, Interactuable
{
    public void Interactuar(GameObject playerGameObject)
    {
        playerGameObject.GetComponent<PlayerController>().hasLlave = true;
        Destroy(gameObject);
    }
}
