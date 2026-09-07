using UnityEngine;

public class LoadNextsceneLlave : LoadNextScene
{
    [SerializeField] private bool requiereLlave;

    public void CerrarPuerta()
    {
        requiereLlave = true;
    }

    protected override void PuedeCambiarEscena(PlayerController player)
    {
        canChange = !requiereLlave || player.hasLlave;
    }
}
