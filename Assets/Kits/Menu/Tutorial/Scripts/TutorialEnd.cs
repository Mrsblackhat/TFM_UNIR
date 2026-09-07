using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Playables;
using System.Linq;

public class TutorialEnd : MonoBehaviour
{
    [SerializeField] private GameObject panelMovimiento;
    [SerializeField] private GameObject panelCamara;

    [SerializeField] private DialogoData dialogo;
    private bool dialogoActivo;

    [SerializeField] private PlayableDirector director;

    private Canvas canvas;
    private GameObject panelActivo;

    private bool puedeCerrar;


    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        panelMovimiento.SetActive(false);
        panelCamara.SetActive(false);

        canvas.enabled = false;
    }

    private void Update()
    {
        if (panelActivo == null || !puedeCerrar) return;

        if (Keyboard.current.anyKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            panelActivo.SetActive(false);
            panelActivo = null;

            canvas.enabled = false;
            puedeCerrar = false;
        }
    }

    private void OnEnable()
    {
        DialogoManager.OnDialogoTerminado += ContinuarTimeline;
    }

    private void OnDisable()
    {
        DialogoManager.OnDialogoTerminado -= ContinuarTimeline;
    }

    public void MostrarDialogoTimeline()
    {
        if (DialogoManager.Instance == null)
            return;

        dialogoActivo = true;

        director.Pause();

        DialogoManager.Instance.IniciarDialogo(dialogo, null);
    }


    private void ContinuarTimeline()
    {
        if(!dialogoActivo) return;

        dialogoActivo = false;
        director.Resume();
    }


    public void MostrarMovimiento()
    {
        canvas.enabled = true;

        panelMovimiento.SetActive(true);
        panelCamara.SetActive(false);

        panelActivo = panelMovimiento;

        puedeCerrar = false;
        StartCoroutine(EsperarParaCerrar());
    }

    public void MostrarCamara()
    {
        canvas.enabled = true;

        panelMovimiento.SetActive(false);
        panelCamara.SetActive(true);

        panelActivo = panelCamara;

        puedeCerrar = false;
        StartCoroutine(EsperarParaCerrar());
    }

    private IEnumerator EsperarParaCerrar()
    {
        yield return new WaitForSeconds(0.2f);
        puedeCerrar = true;
    }
}
