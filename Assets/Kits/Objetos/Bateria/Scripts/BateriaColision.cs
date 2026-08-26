using Unity.VisualScripting;
using UnityEngine;

public class BateriaColision : MonoBehaviour
{
    [SerializeField] public float cura = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BateriaPlayer>(out BateriaPlayer player))
        {
            player.curarJugador(cura);
            Destroy(this.gameObject);
        }
    }
}
