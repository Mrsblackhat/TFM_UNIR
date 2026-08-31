using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BateriaPlayer : MonoBehaviour, Danable
{
    [SerializeField] private float vida = 100f;
    float vidaActual;
    [SerializeField] private BateriaUI bateriaUI;

    private void Awake()
    {
        vidaActual = vida;
    }

    //Probar que funciona
    //[ContextMenu("Quitar vida de prueba")]
    //private void QuitarVidaDePrueba()
    //{
    //    DanarJugador(20f);
    //}

    public void DanarJugador(float dano)
    {
        vidaActual -= dano;
        Debug.Log(vidaActual);

        bateriaUI.ActualizarBateriaHUD(vidaActual);

        if (vidaActual <= 0) 
        {
            Morir();
        }
    }

    internal void Reset()
    {
        vidaActual = vida;

        bateriaUI.ActualizarBateriaHUD(vidaActual);
    }

    private void Morir()
    {
        Debug.Log("tamuertoo");

        FinalMenu.instance.Defeat();
    }

    public void curarJugador(float bateria)
    {
        vida += bateria;
        if (vida >= 100)
        {
            vida = 100;
        }

        Debug.Log(vida);

        bateriaUI.ActualizarBateriaHUD(vidaActual);

        if (vida <= 0)
        {
            Morir();
        }
    }
}
