using System;
using UnityEngine;
using UnityEngine.Events;

public class ItemPosition : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject canvas;
    public bool isCorrect = false; // debug

    public event Action OnCorrectPosition;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Interactuar(GameObject playerGameObject)
    {
        if(isColliding)
        {
            Destroy(itemPrefab);
            PlayerController player = playerGameObject.GetComponent<PlayerController>();
            player.currentItem = null;
            player.QuitarObjetosHUD();

            spriteRenderer.enabled = true;
            spriteRenderer.color = Color.white;
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
