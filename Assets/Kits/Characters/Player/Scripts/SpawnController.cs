using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance;

    public int idSpawn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
