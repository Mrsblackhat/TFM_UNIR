using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    TextMeshProUGUI textComponent;

    private void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void Change(string newText)
    {
        textComponent.text = newText;
    }
}
