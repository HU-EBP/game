using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleLoader : MonoBehaviour
{
    public GameObject[] puzzles;

    private int PreviousScene = 1;
    private int CurrentPuzzle = 0;

    void Start()
    {
        // Get previous scene PlayerPref
        if (!PlayerPrefs.HasInt("PrevScene")) { Debug.LogError("No scene to return to! - This means an unexpected error has occured in the Proximity.CS script. Default scene to return to will be the HomeTown scene."); }
        else { PreviousScene = PlayerPrefs.GetInt("PrevScene"); }

        // Get puzzle number PlayerPref
        if (!PlayerPrefs.HasInt("PuzzleNum")) { Debug.LogError("No puzzle to load! - This either means the PuzzleNum PlayerPref was not assigned in the inspector, or another unexpected error has occured. Only a return to level button will show."); }
        else { CurrentPuzzle = PlayerPrefs.GetInt("PuzzleNum"); }

        // Hide all puzzles
        for (int i = 0; i < puzzles.Length; i++) { puzzles[i].gameObject.SetActive(false); }

        // Only show selected puzzle
        puzzles[CurrentPuzzle].gameObject.SetActive(true);
    }
}
