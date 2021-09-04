using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;

    private static UIManager _instance;
    private FMOD.Studio.Bus musicBus;
    private FMOD.Studio.Bus eventBus;

    public static UIManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {

        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        eventBus = FMODUnity.RuntimeManager.GetBus("bus:/Sound");
        if (soundSlider && musicSlider)
        {
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
                musicBus.setVolume(musicSlider.value);
            }
            if (PlayerPrefs.HasKey("SoundVolume"))
            {
                soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
                eventBus.setVolume(soundSlider.value);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Pause()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
           
    }

    public void goToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void goToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void goToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void quitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void ApplySettings()
    {
        musicBus.setVolume(musicSlider.value);
        eventBus.setVolume(soundSlider.value);

        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SoundVolume", soundSlider.value);
    }
}
