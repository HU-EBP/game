using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResetConfirm : MonoBehaviour
{
    [SerializeField] private PuzzleCheck[] PuzzleChecks;
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private GameObject thisGameObject;
    private int timesClicked = 0;
    private int[] PuzzleInts;

    private void Start()
    {
        textObject.color = Color.red;
        textObject.text = "Resetten?";
        thisGameObject.SetActive(false);

        PuzzleInts = new int[PuzzleChecks.Length];
        for (int i = 0; i < PuzzleChecks.Length; i++) { PuzzleInts[i] = PuzzleChecks.PuzzleInt; }
    }

    public void OnButtonClick()
    {
        if (timesClicked == 1)
        {
            textObject.color = new Color(0.196f, 0.196f, 0.196f, 1);
            textObject.text = "Reset level";

            // Resetting level 1 if this level is active
            if (PlayerPrefs.HasKey("Level1Active"))
            {
                PlayerPrefs.SetInt("WalkTutorial", 0);
                PlayerPrefs.SetInt("JumpTutorial", 0);
                PlayerPrefs.SetInt("EnemyTutorial", 0);
            }

            // Resetting level 2 if this level is active
            if (PlayerPrefs.HasKey("Level2Active"))
            {
                Debug.Log("Level 2 reset");
                PlayerPrefs.SetInt("Checkpoint1", 0);
            }

            // Resetting Puzzle ints
            for (int i = 0; i < PuzzleChecks.Length; i++) { PlayerPrefs.SetInt("Puzzle" + PuzzleInts[i] + "Completed", 0); }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else { timesClicked = 1; }
    }
}