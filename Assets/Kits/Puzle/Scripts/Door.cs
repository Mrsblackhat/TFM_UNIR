using UnityEngine;

public class Door : LoadNextScene
{
    [SerializeField] ItemPosition[] itemPositions;

    private void Awake()
    {
        foreach (ItemPosition item in itemPositions)
        {
            item.OnCorrectPosition += CorrectPositionItem;
        }

        canChange = false;
    }

    int nCorrectItems = 0;
    void CorrectPositionItem()
    {
        nCorrectItems++;

        if (nCorrectItems == itemPositions.Length)
        {
            canChange = true;
        }
    }
}
