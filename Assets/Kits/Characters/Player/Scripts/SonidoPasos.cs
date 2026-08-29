using System.Collections;
using UnityEngine;

public class SonidoPasos : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private PlayerController player;
    [SerializeField] private AudioSource audioSource;

    [Header("Sonidos de pasos")]
    [SerializeField] private AudioClip[] pasos;

    [Header("Tiempos")]
    [SerializeField] private float tiempoEntrePasos = 0.5f;

    [Header("Volumen")]
    [SerializeField] private float volumen = 0.7f;

    private Coroutine rutinaPasos;


    private void Update()
    {
        if (player.moviendose)
        {
            if (rutinaPasos == null)
            {
                rutinaPasos = StartCoroutine(RutinaPasos());
            }
        }
        else
        {
            if (rutinaPasos != null)
            {
                StopCoroutine(rutinaPasos);
                rutinaPasos = null;
            }
        }
    }

    private IEnumerator RutinaPasos()
    {
        while (player.moviendose)
        {
            ReproducirPaso();

            //if (player.corriendo)
            //{
            //    yield return new WaitForSeconds(tiempoEntrePasosCorriendo);
            //}
            //else
            //{
            //    yield return new WaitForSeconds(tiempoEntrePasosCaminando);
            //}

            yield return new WaitForSeconds(tiempoEntrePasos);
        }

        rutinaPasos = null;
    }

    private void ReproducirPaso()
    {
        if (pasos.Length == 0)
            return;

        int indice = Random.Range(0, pasos.Length);
        AudioClip paso = pasos[indice];

        audioSource.PlayOneShot(paso, volumen);
    }
}