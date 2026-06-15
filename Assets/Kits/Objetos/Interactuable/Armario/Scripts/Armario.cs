using UnityEngine;

public class Armario : MonoBehaviour, Interactuable
{
    public void Interactuar(GameObject playerGameObject)
    {
        PlayerHide playerHide = playerGameObject.GetComponent<PlayerHide>();

        if (playerHide != null)
        {
            if (playerHide.EstaEscondido)
            {
                playerHide.SalirArmario();
            }
            else
            {
                playerHide.EntrarArmario(this);
            }
        }
    }
}
