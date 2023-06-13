using UnityEngine;
using TMPro;

public class DebugLevel2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ButtonText;
    [SerializeField] private bool IsCompleteButton = false;
    private bool Level2 = false;

    private void Start() { if (IsCompleteButton) { SetButtonText(); } }

    // Function to change the completion status of level 2
    public void ChangeCompleteState()
    {
        if (PlayerPrefs.HasKey("Level2Complete"))
        {
            Level2 = PlayerPrefs.GetInt("Level2Complete") == 1 ? true : false;
            if (Level2)
            {
                PlayerPrefs.SetInt("Level2Complete", 0);
                SetButtonText();
            }
            else if (!Level2)
            {
                PlayerPrefs.SetInt("Level2Complete", 1);
                SetButtonText();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level2Complete", 1);
            SetButtonText();
        }
    }

    // Function to change button text of a completion button
    private void SetButtonText()
    {
        if (PlayerPrefs.HasKey("Level2Complete"))
        {
            Level2 = PlayerPrefs.GetInt("Level2Complete") == 1 ? true : false;
            if (Level2) { ButtonText.text = "Level 2 gehaald: TRUE"; }
            else if (!Level2) { ButtonText.text = "Level 2 gehaald: FALSE"; }
        }
        else { ButtonText.text = "Level 2 gehaald: FALSE"; }
    }

    // Function to hard reset level 2
    public void HardResetL2()
    {
        if (PlayerPrefs.HasKey("Level2Complete")) { PlayerPrefs.DeleteKey("Level2Complete"); }
        if (PlayerPrefs.HasKey("DidPuzzle")) { PlayerPrefs.DeleteKey("DidPuzzle"); }
        if (PlayerPrefs.HasKey("Checkpoint1")) { PlayerPrefs.DeleteKey("Checkpoint1"); }
        if (PlayerPrefs.HasKey("StopShowingL2Checkpoint")) { PlayerPrefs.DeleteKey("StopShowingL2Checkpoint"); }
        if (PlayerPrefs.HasKey("StopShowingL2Secret")) { PlayerPrefs.DeleteKey("StopShowingL2Secret"); }
        Debug.Log("Level 2 was hard reset, restarting the level is recommended if you are currently in level 2.");
    }
}
