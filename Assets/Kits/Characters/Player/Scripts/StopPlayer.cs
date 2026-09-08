using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    [SerializeField] private GameObject triggerCambio;
    [SerializeField] private GameObject triggerDialogo;

    PlayerController playerControl;

    private void Awake()
    {
        playerControl = FindFirstObjectByType<PlayerController>();
    }

    private void Start()
    {
        if (playerControl == null) return;

        else
        {
            if (!playerControl.parteSuperiorVisitada)
            {
                DesactivarTriggers();
            }

            else
            {
                ActivarTriggers();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if(player != null)
        {
            player.parteSuperiorVisitada = true;
            ActivarTriggers();
        }
    }

    private void DesactivarTriggers()
    {
        triggerCambio.SetActive(false);
        triggerDialogo.SetActive(true);
    }

    private void ActivarTriggers()
    {
        triggerCambio.SetActive(true);
        triggerDialogo.SetActive(false);
    }

    //[SerializeField] public DialogoData dialogo;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (DialogoManager.Instance != null)
    //    {
    //        DialogoManager.Instance.IniciarDialogo(dialogo, null);
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}
}
