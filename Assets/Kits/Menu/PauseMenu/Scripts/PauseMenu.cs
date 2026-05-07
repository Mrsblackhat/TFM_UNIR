using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Settings reference")]
    [SerializeField] Settings settings;

    [Header("Canvas elements")]
    [SerializeField] GameObject canvasMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject pauseContent;

    [Header("SFX")]
    [SerializeField] AudioClip clickSFX;
    [SerializeField] AudioClip mouseSFX;
    [SerializeField] AudioClip openMenu;
    [SerializeField] AudioClip closeMenu;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        canvasMenu.GetComponent<Canvas>().enabled = false;
    }

    bool pauseOpen = false;
    private void Update()
    {
        //cambiar
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !pauseOpen)
        {
            pauseOpen = true;

            OpenMenu();
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame && pauseOpen)
        {
            pauseOpen = false;

            CloseMenu();
        }
    }

    public void OpenMenu()
    {
        canvasMenu.GetComponent<Canvas>().enabled = true;
        source.PlayOneShot(openMenu);

        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        canvasMenu.GetComponent<Canvas>().enabled = false;
        source.PlayOneShot(closeMenu);

        Time.timeScale = 1;
    }

    public void Resume()
    {
        source.PlayOneShot(clickSFX);

        pauseOpen = false;

        CloseMenu();
    }

    public void OpenSettings()
    {
        source.PlayOneShot(clickSFX);

        settingsMenu.SetActive(true);
        pauseContent.SetActive(false);

        settings.OnSettingsSaved += OnCloseSettings;
    }

    public void OnCloseSettings()
    {
        source.PlayOneShot(clickSFX);

        settingsMenu.SetActive(false);
        pauseContent.SetActive(true);

        settings.OnSettingsSaved -= OnCloseSettings;
    }

    public void ExitToMainMenu()
    {
        source.PlayOneShot(clickSFX);

        pauseOpen = true;
        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");
    }

    public void MouseAudio()
    {
        source.PlayOneShot(mouseSFX);
    }
}
