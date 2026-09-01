using UnityEngine;
using UnityEngine.AI;

public class Damage : MonoBehaviour
{
    [SerializeField] float danho = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Danable>(out Danable danable))
        {
            danable.DanarJugador(danho);
        }
    }
}
