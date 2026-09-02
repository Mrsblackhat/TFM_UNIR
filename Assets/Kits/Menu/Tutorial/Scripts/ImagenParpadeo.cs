using UnityEngine;
using UnityEngine.UI;

public class ImagenParpadeo : MonoBehaviour
{
    [SerializeField] private Sprite imagen1;
    [SerializeField] private Sprite imagen2;
    [SerializeField] private float intervalo = 1f;

    private Image imagen;
    float tRestante;
    private bool mostrandoI1 = true;

    private void Awake()
    {
        imagen = GetComponent<Image>();
        imagen.sprite = imagen1;

        tRestante = intervalo;
    }

    void Update()
    {
        tRestante -= Time.deltaTime;

        if (tRestante <= 0f)
        {
            if (mostrandoI1)
            {
                imagen.sprite = imagen2;
                mostrandoI1 = false;
            }
            else
            {
                imagen.sprite = imagen1;
                mostrandoI1 = true;
            }

            tRestante = intervalo;
        }
    }
}
