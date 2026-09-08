using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class des_aparecer : MonoBehaviour
{
    [SerializeField] GameObject puerta;
    [SerializeField] PlayableDirector timeline;

    [SerializeField] private DialogoData dialogo1;
    [SerializeField] private DialogoData dialogo2;

    [Header("Objetos")]
    [SerializeField] private GameObject objetos;
    [SerializeField] private GameObject cuadro;
    [SerializeField] private GameObject manta;

    [Header("Música")]
    [SerializeField] private AudioClip tensionOST;

    private LoadNextsceneLlave llave;


    private bool dialogoActivo;


    private void Awake()
    {
        llave = puerta.GetComponent<LoadNextsceneLlave>();
    }

    private void Start()
    {
        objetos.SetActive(false);
        manta.SetActive(false);
        cuadro.SetActive(true);
    }

    private void OnEnable()
    {
        DialogoManager.OnDialogoTerminado += ContinuarTimeline;
    }

    private void OnDisable()
    {
        DialogoManager.OnDialogoTerminado -= ContinuarTimeline;
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
                llave.CerrarPuerta();
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

    public void PrimerDialogo()
    {
        if (DialogoManager.Instance == null)
            return;

        dialogoActivo = true;
        timeline.Pause();

        DialogoManager.Instance.IniciarDialogo(dialogo1, null);
    }

    public void MostrarDialogoTimeline()
    {
        if (DialogoManager.Instance == null)
            return;

        DialogoManager.Instance.IniciarDialogo(dialogo2, null);
    }

    public void OcultarDialogoTimeline()
    {
        DialogoManager.Instance.TerminarDialogo();
    }

    private void ContinuarTimeline()
    {
        if (!dialogoActivo) return;

        dialogoActivo = false;
        timeline.Resume();
    }
}
