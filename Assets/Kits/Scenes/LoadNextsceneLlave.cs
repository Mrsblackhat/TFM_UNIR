using UnityEngine;

public class LoadNextsceneLlave : LoadNextScene
{
    protected override void PuedeCambiarEscena(PlayerController player)
    {
        canChange = player.hasLlave;
    }
}
