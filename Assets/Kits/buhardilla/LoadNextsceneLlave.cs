using UnityEngine;

public class LoadNextsceneLlave : LoadNextScene
{
    protected override bool PuedeCambiarEscena(PlayerController player)
    {
        return player.hasLlave;
    }
}
