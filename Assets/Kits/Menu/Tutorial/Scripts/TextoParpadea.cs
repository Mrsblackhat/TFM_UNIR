using TMPro;
using UnityEngine;

public class TextoParpadea : MonoBehaviour
{
    TextMeshProUGUI text;

    float intervalo = 1;
    float tRestante;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        tRestante = intervalo;
    }

    private void Update()
    {
        tRestante -= Time.deltaTime;

        if (tRestante <= 0)
        {
            text.enabled = !text.enabled;
            tRestante = intervalo;
        }
    }
}
