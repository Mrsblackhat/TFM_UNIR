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

        bateriaUI.ActualizarBateriaHUD(vida);

        if (vidaActual <= 0) 
        {
            Morir();
        }
    }

    internal void Reset()
    {
        vidaActual = vida;
    }

    private void Morir()
    {
        Debug.Log("tamuertoo");

        FinalMenu.instance.Defeat();
    }
}
