using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] ItemPosition[] itemPositions;

    private void Awake()
    {
        foreach (ItemPosition item in itemPositions)
        {
            item.OnCorrectPosition += CorrectPositionItem;
        }
    }

    int nCorrectItems = 0;
    void CorrectPositionItem()
    {
        nCorrectItems++;

        if (nCorrectItems == itemPositions.Length)
        {
            Debug.Log("Puerta abierta");
            GetComponent<SpriteRenderer>().color = Color.red; // pruebas
        }
    }
}
