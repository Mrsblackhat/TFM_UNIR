using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
    public static DialogoManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text nombreTexto;
    [SerializeField] private TMP_Text fraseTexto;
    [SerializeField] private Image imagenPersonaje;

    [Header("Velocidad")]
    [SerializeField] private float letrasPorSegundo = 40f;

    [Header("Cerrar al alaejarse")]
    [SerializeField] private float distanciaCierre = 4f;

    private readonly Queue<string> frases = new Queue<string>();

    private Coroutine escrituraCoroutine;
    private string fraseActual;
    private bool estaEscribiendo;

    private Transform objetoOrigen;
    private Transform player;


    public bool DialogoAbierto { get; private set; }
    public bool DebeBloquearJugador => DialogoAbierto && estaEscribiendo;
    public static bool HayDialogoAbierto => Instance != null && Instance.DialogoAbierto;
    public static bool BloqueaJugador => Instance != null && Instance.DebeBloquearJugador;


    public static event System.Action OnDialogoTerminado;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        panelDialogo.SetActive(false);

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
    }

    private void Update()
    {
        ComprobarDistanciaAlPlayer();
    }

    private void ComprobarDistanciaAlPlayer()
    {
        if(!DialogoAbierto)
        { return; }

        if(objetoOrigen == null || player == null)
        { return; }

        float distancia = Vector2.Distance(player.position, objetoOrigen.position);
        Debug.Log("La distancia es" + distancia);

        if(distancia > distanciaCierre)
        { TerminarDialogo(); }
    }


    public void IniciarDialogo(DialogoData dialogoData, Transform origen)
    {
        if (dialogoData == null)
        {
            Debug.Log("Diálogo vacío");
            return;
        }

        objetoOrigen = origen;

        DialogoAbierto = true;

        panelDialogo.SetActive(true);

        nombreTexto.text = dialogoData.NombrePersonaje;
        imagenPersonaje.sprite = dialogoData.ImagenPersonaje;
        fraseTexto.text = "";

        frases.Clear();

        foreach (string frase in dialogoData.Frases)
        {
            frases.Enqueue(frase);
        }

        SiguienteFrase();
    }

    public void SiguienteFrase()
    {
        //if(!DialogoAbierto)
        //{ return; }

        if (estaEscribiendo)
        {
            CompletarFraseInstantaneamente();
            return;
        }

        if (frases.Count == 0)
        {
            TerminarDialogo();
            OnDialogoTerminado?.Invoke();
            return;
        }

        fraseActual = frases.Dequeue();

        escrituraCoroutine = StartCoroutine(EscribirFrase(fraseActual));
    }

    private IEnumerator EscribirFrase(string frase)
    {
        estaEscribiendo = true;
        fraseTexto.text = "";

        foreach (char letra in frase)
        {
            fraseTexto.text += letra;

            yield return new WaitForSeconds(1f / letrasPorSegundo);
        }

        estaEscribiendo = false;
        escrituraCoroutine = null;
    }

    private void CompletarFraseInstantaneamente()
    {
        if (escrituraCoroutine != null)
        {
            StopCoroutine(escrituraCoroutine);
            escrituraCoroutine = null;
        }

        fraseTexto.text = fraseActual;
        estaEscribiendo = false;
    }

    public void TerminarDialogo()
    {
        if(escrituraCoroutine != null)
        {
            StopCoroutine(escrituraCoroutine);
            escrituraCoroutine = null;
        }

        estaEscribiendo = false;
        DialogoAbierto = false;

        panelDialogo.SetActive(false);

        nombreTexto.text = "";
        fraseTexto.text = "";
        imagenPersonaje.sprite = null;

        frases.Clear();

        objetoOrigen = null;
    }
}
