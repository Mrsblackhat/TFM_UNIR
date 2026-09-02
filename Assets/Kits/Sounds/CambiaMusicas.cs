using UnityEngine;

public class CambiaMusicas : MonoBehaviour
{
    [SerializeField] AudioClip musica;

    private void Awake()
    {
        if (MusicManager.Instance != null)
        {
            //MusicManager.Instance.musica.clip = musica;
            MusicManager.Instance.musica.PlayOneShot(musica);
        }
    }
}
