using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    [SerializeField] GameObject victoryCanvas;
    [SerializeField] GameObject defeatCanvas;

    [SerializeField] AudioClip victory;
    [SerializeField] AudioClip defeat;

    AudioSource source;

    public static FinalMenu instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        source = GetComponent<AudioSource>();

        victoryCanvas.SetActive(false);
        defeatCanvas.SetActive(false);
    }

    public void Win()
    {
        victoryCanvas.SetActive(true);
        source.PlayOneShot(victory);

        Time.timeScale = 0;
    }

    public void Defeat()
    {
        defeatCanvas.SetActive(true);
        source.PlayOneShot(defeat);

        Time.timeScale = 0;
    }

    public void DefeatRestart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VictoryRestart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("dormitorio");
    }

    public void Exit()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");
    }
}
