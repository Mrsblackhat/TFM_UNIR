using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int id;

    private void Start()
    {
        if (SpawnController.instance.idSpawn == id)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = transform.position;
            }
        }
    }
}
