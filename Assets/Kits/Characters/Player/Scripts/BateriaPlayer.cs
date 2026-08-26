using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BateriaPlayer : MonoBehaviour, Danable
{
    [SerializeField] private float vida = 100f;
    [SerializeField] private BateriaUI bateriaUI;

    //Probar que funciona
    //[ContextMenu("Quitar vida de prueba")]
    //private void QuitarVidaDePrueba()
    //{
    //    DanarJugador(20f);
    //}

    public void DanarJugador(float dano)
    {
        vida -= dano;
        Debug.Log(vida);

        bateriaUI.ActualizarBateriaHUD(vida);

        if (vida <= 0) 
        {
            Morir();
        }
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

        bateriaUI.ActualizarBateriaHUD(vida);

        if (vida <= 0)
        {
            Morir();
        }
    }
}
