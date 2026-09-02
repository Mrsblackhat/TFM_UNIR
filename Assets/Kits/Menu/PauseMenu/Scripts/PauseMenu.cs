using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Settings reference")]
    [SerializeField] Settings settings;

    [Header("Input Action Reference")]
    [SerializeField] InputActionReference inputReference;

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

    public static PauseMenu instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        source = GetComponent<AudioSource>();

        canvasMenu.GetComponent<Canvas>().enabled = false;
    }

    private void OnEnable()
    {
        inputReference.action.Enable();
        inputReference.action.started += OnPause;
    }

    private void OnDisable()
    {
        inputReference.action.Disable();
        inputReference.action.started -= OnPause;
    }

    public bool pauseOpen { set; get; }

    private void OnPause(InputAction.CallbackContext ctx)
    {
        pauseOpen = !pauseOpen;

        if (pauseOpen) OpenMenu();
        else CloseMenu();
    }

    public void OpenMenu()
    {
        canvasMenu.GetComponent<Canvas>().enabled = true;
        source.PlayOneShot(openMenu);

        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        if (settingsOpen) OnCloseSettings();

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

    bool settingsOpen = false;
    public void OpenSettings()
    {
        source.PlayOneShot(clickSFX);

        settingsOpen = true;
        settingsMenu.GetComponent<Canvas>().enabled = true;
        pauseContent.SetActive(false);

        settings.OnSettingsSaved += OnCloseSettings;
    }

    public void OnCloseSettings()
    {
        source.PlayOneShot(clickSFX);

        settingsOpen = false;
        settingsMenu.GetComponent<Canvas>().enabled = false;
        pauseContent.SetActive(true);

        settings.OnSettingsSaved -= OnCloseSettings;
    }

    public void ExitToMainMenu()
    {
        source.PlayOneShot(clickSFX);

        pauseOpen = true;
        Time.timeScale = 1;

        canvasMenu.GetComponent<Canvas>().enabled = false;

        SceneManager.LoadScene("MainMenu");
    }

    public void MouseAudio()
    {
        source.PlayOneShot(mouseSFX);
    }
}