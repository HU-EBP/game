using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject optionsScreen;
    public GameObject startMenu;
    public AudioSource audio;

    public void PlayButtonClick()
    {
        audio.Play();
    }

    void Start()
    {
        // Hide options screen when game starts
        optionsScreen.SetActive(false);
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        // When start is clicked, load the first level by adding 1 to the current scene index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions()
    {
        // Hide the start menu
        startMenu.SetActive(false);

        // Open options screen
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        // Show the start menu
        startMenu.SetActive(true);

        // Close options screen
        optionsScreen.SetActive(false);

        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
