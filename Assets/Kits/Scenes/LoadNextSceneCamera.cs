using UnityEngine;

public class LoadNextSceneCamera : LoadNextScene
{
    protected override void PuedeCambiarEscena(PlayerController player)
    {
        canChange = player.hasCamera;
    }
}
