using System;
using UnityEngine;
using UnityEngine.Events;

public class ItemPosition : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject canvas;
    bool isCorrect = false;

    public event Action OnCorrectPosition;

    private void Update()
    {
        if (!isCorrect)
        {
            if (!itemPrefab.GetComponent<Item>().pickedUp && isColliding)
            {
                itemPrefab.GetComponent<Item>().canBePicked = false;
                itemPrefab.transform.position = transform.position;
                isCorrect = true;
                OnCorrectPosition?.Invoke();
            }
        }
    }

    bool isColliding;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == itemPrefab)
        {
            isColliding = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == itemPrefab)
        {
            isColliding = false;
            canvas.SetActive(false);
        }

        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
