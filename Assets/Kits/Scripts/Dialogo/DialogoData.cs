using UnityEngine;


[CreateAssetMenu(menuName = "Dialogo/Nuevo Dialogo")]

public class DialogoData : ScriptableObject
{
    [SerializeField] private string nombrePersonaje;

    [TextArea(2, 5)]
    [SerializeField] private string[] frases;

    public string NombrePersonaje => nombrePersonaje;
    public string[] Frases => frases;
}

