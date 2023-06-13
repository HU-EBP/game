using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public static bool isGamePaused = false;
    public KeybindManager keybindManager;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !keybindManager.IsRebinding)
        {
            if (isGamePaused) { Resume(); }
            else { Pause(); }
        }
    }

    public void BackToHome()
    {
        // When button is pressed, load the scene with the index of the current scene - 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void BackTwoScenes()
    {
        // When button is pressed, load the scene with the index of the current scene - 2
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void OpenOptionsMenu()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void CloseOptionsMenu()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
