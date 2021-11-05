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
    bool init = false;

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

        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        eventBus = FMODUnity.RuntimeManager.GetBus("bus:/Sound");

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicBus.setVolume(PlayerPrefs.GetFloat("MusicVolume"));
            Debug.Log("set music volume to: " + PlayerPrefs.GetFloat("MusicVolume"));
        }
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            eventBus.setVolume(PlayerPrefs.GetFloat("SoundVolume"));
        }
        if (soundSlider && musicSlider)
        {
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            init = true;
        }
    }



    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        SceneManager.LoadScene("Level_1");
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
        if (!init) return;
        musicBus.setVolume(musicSlider.value);
        eventBus.setVolume(soundSlider.value);

        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SoundVolume", soundSlider.value);
    }
}
