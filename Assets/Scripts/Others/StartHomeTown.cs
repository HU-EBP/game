using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHomeTown : MonoBehaviour
{
    [SerializeField] private int NumPuzzles;
    public static bool isGamePaused;
    void Start()
    {
        // When scene is loaded, set the time scale to 1
        Time.timeScale = 1f;
        isGamePaused = false;

        // Delete all level-based playerprefs
        for (int i = 0; i <= NumPuzzles; i++) { if (PlayerPrefs.HasKey("Puzzle" + i + "Completed")) { PlayerPrefs.DeleteKey("Puzzle" + i + "Completed"); } }
        if (PlayerPrefs.HasKey("WalkTutorial")) { PlayerPrefs.DeleteKey("WalkTutorial"); }
        if (PlayerPrefs.HasKey("JumpTutorial")) { PlayerPrefs.DeleteKey("JumpTutorial"); }
        if (PlayerPrefs.HasKey("EnemyTutorial")) { PlayerPrefs.DeleteKey("EnemyTutorial"); }
        if (PlayerPrefs.HasKey("Checkpoint1")) { PlayerPrefs.DeleteKey("Checkpoint1"); }
    }
}