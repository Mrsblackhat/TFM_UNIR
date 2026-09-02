using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] public AudioSource musica;
    [SerializeField] private AudioSource ambiente;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        musica.Play();
        ambiente.Play();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Armario" || scene.name == "pasilloPersecucion" || scene.name == "dormitorioFinal")
        {
            musica.Stop();
            ambiente.Stop();
        }
        else if (mode != LoadSceneMode.Additive)
        {
            Debug.Log(musica.isPlaying);

            if (!musica.isPlaying)
            {
                musica.Play();
            }
        }
    }
}
