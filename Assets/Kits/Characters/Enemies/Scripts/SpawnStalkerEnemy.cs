using UnityEngine;

public class SpawnStalkerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.SetActive(true);
        }
}}
