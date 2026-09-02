using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class des_aparecer : MonoBehaviour
{
    [SerializeField] GameObject puerta;
    [SerializeField] PlayableDirector timeline;

    [SerializeField] private DialogoData dialogo;

    [Header("Objetos")]
    [SerializeField] private GameObject objetos;
    [SerializeField] private GameObject cuadro;
    [SerializeField] private GameObject manta;

    [Header("Música")]
    [SerializeField] private AudioClip tensionOST;

    private void Start()
    {
        objetos.SetActive(false);
        manta.SetActive(false);
        cuadro.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (!player.buhardillaVisitada)
            {
                timeline.Play();
                Debug.Log("Le doy al play");
                player.buhardillaVisitada = true;
            }

            else if (player.buhardillaVisitada && player.hasLlave)
            {
                objetos.SetActive(true);
                manta.SetActive(true);
                cuadro.SetActive(false);

                if (MusicManager.Instance != null)
                {
                    MusicManager.Instance.musica.clip = tensionOST;
                    MusicManager.Instance.musica.PlayOneShot(tensionOST);
                }
            }

            Debug.Log("Player ha entrado. Llave: " + player.hasLlave);
            //puerta.SetActive(player.hasLlave);         
        }
    }

    public void MostrarDialogoTimeline()
    {
        if (DialogoManager.Instance == null)
            return;

        DialogoManager.Instance.IniciarDialogo(dialogo, null);
    }

    public void OcultarDialogoTimeline()
    {
        DialogoManager.Instance.TerminarDialogo();
    }
}
