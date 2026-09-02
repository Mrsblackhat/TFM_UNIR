using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    [SerializeField] GameObject victoryCanvas;
    [SerializeField] GameObject defeatCanvas;

    [SerializeField] AudioClip victory;
    [SerializeField] AudioClip defeat;

    AudioSource source;

    public bool activo { set; get; }
    /// <summary>
    /// ///////
    /// </summary>
    public static FinalMenu instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        source = GetComponent<AudioSource>();

        victoryCanvas.GetComponent<Canvas>().enabled = false;
        defeatCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void Win()
    {
        activo = true;

        victoryCanvas.GetComponent<Canvas>().enabled = true;
        source.PlayOneShot(victory);

        Time.timeScale = 0;
    }

    public void Defeat()
    {
        activo = true;

        defeatCanvas.GetComponent<Canvas>().enabled = true;
        source.PlayOneShot(defeat);

        Time.timeScale = 0;
    }

    public void DefeatRestart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        defeatCanvas.GetComponent<Canvas>().enabled = false;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerController>().RestartBattery();
            //player.GetComponent<PlayerController>().RebuscarWendigos();

        }

        activo = false;
    }

    public void VictoryRestart()
    {
        Time.timeScale = 1;

        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //if (player != null)
        //{
        //    Destroy(player);
        //}

        Indestructible[] indestuctibles = GameObject.FindObjectsByType<Indestructible>(FindObjectsSortMode.None);
        foreach (Indestructible indestructible in indestuctibles)
        {
            Destroy(indestructible.gameObject);
        }

        SceneManager.LoadScene("dormitorio");

        victoryCanvas.GetComponent<Canvas>().enabled = false;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().RestartBattery();
        
        activo = false;
    }

    public void Exit()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");
    }
}
