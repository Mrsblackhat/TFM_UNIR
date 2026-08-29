using UnityEngine;
using UnityEngine.UI;

public class BateriaUI : MonoBehaviour
{
    [SerializeField] private Image bateriaRelleno;
    [SerializeField] private Image fundidoANegro;
    [SerializeField] private float opacidadMax;

    public void ActualizarBateriaHUD(float bateria)
    {
        float porcentaje = bateria * 0.01f;

        bateriaRelleno.fillAmount = porcentaje;

        Color color = fundidoANegro.color;
        color.a = (1f - porcentaje) * (opacidadMax / 255f);

        fundidoANegro.color = color;
    }
}
