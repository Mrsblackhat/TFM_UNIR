using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    [SerializeField] public DialogoData dialogo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DialogoManager.Instance != null)
        {
            DialogoManager.Instance.IniciarDialogo(dialogo, null);
        }
        else
        {
            return;
        }
    }
}
