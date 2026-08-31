using System;
using UnityEngine;
using UnityEngine.Events;

public class ItemPosition : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject canvas;
    public bool isCorrect = false; // debug

    public event Action OnCorrectPosition;

    private void Update()
    {
        if (!isCorrect)
        {
            if (!itemPrefab.GetComponent<Item>().pickedUp && isColliding)
            {
                Destroy(itemPrefab);
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<SpriteRenderer>().color = Color.white;
                GetComponent<PauseSecrets>().enabled = false;
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
