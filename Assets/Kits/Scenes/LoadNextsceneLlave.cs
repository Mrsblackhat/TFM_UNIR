using UnityEngine;

public class LoadNextsceneLlave : LoadNextScene
{
    [SerializeField] private bool requiereLlave;
    [SerializeField] public GameObject bloqueoBuhardilla;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        bloqueoBuhardilla.SetActive(false);
        base.OnTriggerEnter2D(collision);
    }

    public void CerrarPuerta()
    {
        requiereLlave = true;
    }

    protected override void PuedeCambiarEscena(PlayerController player)
    {
        canChange = !requiereLlave || player.hasLlave;
    }
}
