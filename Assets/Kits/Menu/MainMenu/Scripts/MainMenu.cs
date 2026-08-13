using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Settings reference")]
    [SerializeField] Settings settings;

    [Header("Canvas elements")]
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject buttons;

    [Header("SFX")]
    [SerializeField] AudioClip clickSFX;
    [SerializeField] AudioClip mouseSFX;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        source.PlayOneShot(clickSFX);

        AsyncOperation operation = SceneManager.LoadSceneAsync("PantallaCarga", LoadSceneMode.Additive);
        StartCoroutine(EsperaCarga());
    }

    IEnumerator EsperaCarga()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.UnloadSceneAsync("PantallaCarga");
        SceneManager.LoadScene("dormitorio");

    }

    public void OpenSettings()
    {
        source.PlayOneShot(clickSFX);

        settingsMenu.SetActive(true);
        buttons.SetActive(false);

        settings.OnSettingsSaved += OnCloseSettings;
    }

    public void OnCloseSettings()
    {
        source.PlayOneShot(clickSFX);

        settingsMenu.SetActive(false);
        buttons.SetActive(true);

        settings.OnSettingsSaved -= OnCloseSettings;
    }

    public void QuitGame()
    {
        source.PlayOneShot(clickSFX);

        Application.Quit();
    }

    public void MouseAudio()
    {
        source.PlayOneShot(mouseSFX);
    }
}
