using TMPro;
using UnityEngine;

public class Parpadeo : MonoBehaviour
{
    private TMP_Text texto;
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float alphaMin = 0.3f;
    [SerializeField] private float alphaMax = 1f;

    private void Awake()
    {
        texto = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        float alpha = Mathf.Lerp(alphaMin, alphaMax, (Mathf.Sin(Time.time * velocidad) + 1f) / 2f);

        Color color = texto.color;
        color.a = alpha;
        texto.color = color;
    }
}
