using UnityEngine;
using UnityEngine.UI;

public class BateriaUI : MonoBehaviour
{
    [SerializeField] private Image bateriaRelleno;

    public void ActualizarBateriaHUD(float bateria)
    {
        bateriaRelleno.fillAmount = bateria * 0.01f;
    }
}
