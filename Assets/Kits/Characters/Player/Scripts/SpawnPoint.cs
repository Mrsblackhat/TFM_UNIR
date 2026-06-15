using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private void Awake()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = spawnPoint.position;
    }
}
