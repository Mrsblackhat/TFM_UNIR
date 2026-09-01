using System;
using UnityEngine;
using UnityEngine.Events;

public class ItemPosition : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject canvas;
    public bool isCorrect = false; // debug

    public event Action OnCorrectPosition;

    public void Interactuar(GameObject playerGameObject)
    {
        if(isColliding)
        {
            Destroy(itemPrefab);
            playerGameObject.GetComponent<PlayerController>().currentItem = null;

            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<PauseSecrets>().enabled = false;

            isCorrect = true;
            OnCorrectPosition?.Invoke();
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
