using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;


    private static UIManager _instance;
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
}
