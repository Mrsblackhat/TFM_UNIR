using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TutorialEnd : MonoBehaviour
{
    [SerializeField] private GameObject panelMovimiento;
    [SerializeField] private GameObject panelCamara;

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
        Debug.Log("AbroCamara");
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
