using UnityEngine;

public class StartHomeTown : MonoBehaviour
{
    [SerializeField] private GameObject WalkTutorial;
    [SerializeField] private GameObject Level1Arrow;
    [SerializeField] private GameObject Level2Arrow;
    [SerializeField] private int NumPuzzles;
    public static bool isGamePaused;
    void Start()
    {
        // When scene is loaded, set the time scale to 1
        Time.timeScale = 1f;
        isGamePaused = false;

        // Delete all in-level playerprefs
        for (int i = 0; i <= NumPuzzles; i++) { if (PlayerPrefs.HasKey("Puzzle" + i + "Completed")) { PlayerPrefs.DeleteKey("Puzzle" + i + "Completed"); } }
        if (PlayerPrefs.HasKey("WalkTutorial")) { PlayerPrefs.DeleteKey("WalkTutorial"); }
        if (PlayerPrefs.HasKey("JumpTutorial")) { PlayerPrefs.DeleteKey("JumpTutorial"); }
        if (PlayerPrefs.HasKey("EnemyTutorial")) { PlayerPrefs.DeleteKey("EnemyTutorial"); }
        if (PlayerPrefs.HasKey("Checkpoint1")) { PlayerPrefs.DeleteKey("Checkpoint1"); }

        // Hide & show appropriate arrow pointers for level 1/2
        if (PlayerPrefs.HasKey("Level1Complete"))
        {
            if (PlayerPrefs.GetInt("Level1Complete") == 1)
            {
                Level1Arrow.SetActive(false);
                Level2Arrow.SetActive(true);
                WalkTutorial.SetActive(false);
            }
        }
        if (PlayerPrefs.HasKey("Level2Complete"))
        {
            if (PlayerPrefs.GetInt("Level2Complete") == 1)
            {
                Level1Arrow.SetActive(false);
                Level2Arrow.SetActive(false);
                WalkTutorial.SetActive(false);
            }
        }
    }
}