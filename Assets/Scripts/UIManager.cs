using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
