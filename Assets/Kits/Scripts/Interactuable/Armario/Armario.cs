using UnityEngine;

public class Armario : MonoBehaviour, Interactuable
{
    private PlayerHide playerHide;

    public void Interactuar()
    {
        if (playerHide == null)
        {
            playerHide = FindFirstObjectByType<PlayerHide>();
        }

        if (playerHide.estaEscondido)
        {
            playerHide.SalirArmario();
        }
        else 
        {
            playerHide.EntrarArmario(this);
        }
    }
}
