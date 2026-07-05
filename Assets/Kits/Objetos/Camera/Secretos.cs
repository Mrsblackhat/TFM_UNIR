using UnityEngine;

public class Secretos : MonoBehaviour, IAfectadoPorCamara
{
    [SerializeField] private GameObject secret;

    void IAfectadoPorCamara.CambiarEstadoCamara(bool camaraActiva)
    {
        secret.SetActive(camaraActiva);
    }
}
