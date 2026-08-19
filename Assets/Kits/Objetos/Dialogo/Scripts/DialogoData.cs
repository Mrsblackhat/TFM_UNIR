using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Dialogo/Nuevo Dialogo")]

public class DialogoData : ScriptableObject
{
    [SerializeField] private string nombrePersonaje;

    [TextArea(2, 5)]
    [SerializeField] private string[] frases;

    [SerializeField] private Sprite imagenPersonaje;

    public string NombrePersonaje => nombrePersonaje;
    public string[] Frases => frases;

    public Sprite ImagenPersonaje => imagenPersonaje;

}

