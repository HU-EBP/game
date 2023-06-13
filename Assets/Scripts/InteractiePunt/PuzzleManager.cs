using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public bool IsCompleted;
    [SerializeField] private GameObject[] puzzles;

    private int CurrentPuzzle;
    private int PreviousScene;

    void Start()
    {
        // Set vars to defaults to prevent errors
        IsCompleted = false;
        CurrentPuzzle = 0;
        PreviousScene = 1;

        // Get puzzle number PlayerPref
        if (!PlayerPrefs.HasKey("PuzzleNum")) { Debug.LogError("No puzzle to load! - This either means the PuzzleNum PlayerPref was not assigned in the inspector, or another unexpected error has occured. Only a return to level button will show."); }
        else { CurrentPuzzle = PlayerPrefs.GetInt("PuzzleNum"); }

        // Get previous scene PlayerPref
        if (!PlayerPrefs.HasKey("PrevScene")) { Debug.LogError("No scene to return to! - This means an unexpected error has occured in the Proximity.CS script. Default scene to return to will be the HomeTown scene."); }
        else { PreviousScene = PlayerPrefs.GetInt("PrevScene"); }

        // Hide all puzzles
        for (int i = 0; i < puzzles.Length; i++) { puzzles[i].gameObject.SetActive(false); }

        // Only show selected puzzle
        puzzles[CurrentPuzzle].gameObject.SetActive(true);
    }

    // Function to load level scene on 'return' or 'complete' button click (depending if the puzzle was completed)
    public void DoCheck() { StartCoroutine(CheckIfDone()); }
    private IEnumerator CheckIfDone()
    {
        int CompletedValue = IsCompleted ? 1 : 0;
        yield return new WaitForSeconds(1f);
        if (IsCompleted) { ReturnToScene(); }
    }
    public void ReturnToScene()
    {
        int CompletedValue = IsCompleted ? 1 : 0;
        PlayerPrefs.SetInt("Puzzle" + CurrentPuzzle + "Completed", CompletedValue);
        PlayerPrefs.SetInt("DidPuzzle", 1);
        SceneManager.LoadScene(PreviousScene);
    }
}