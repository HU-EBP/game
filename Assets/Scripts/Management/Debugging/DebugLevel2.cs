using UnityEngine;
using TMPro;

public class DebugLevel2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ButtonText;
    [SerializeField] private bool IsCompleteButton = false;
    [SerializeField] private bool IsCheckpointButton = false;
    private bool Level2 = false;
    private bool Level2CP = false;

    private void Start()
    {
        if (IsCompleteButton) { SetCompleteText(); }
        if (IsCheckpointButton) { SetCheckpointText(); }
    }

    // Function to change the completion status of level 2
    public void ChangeCompleteState()
    {
        if (PlayerPrefs.HasKey("Level2Complete"))
        {
            Level2 = PlayerPrefs.GetInt("Level2Complete") == 1 ? true : false;
            if (Level2)
            {
                PlayerPrefs.SetInt("Level2Complete", 0);
                SetCompleteText();
            }
            else if (!Level2)
            {
                PlayerPrefs.SetInt("Level2Complete", 1);
                SetCompleteText();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level2Complete", 1);
            SetCompleteText();
        }
    }

    // Function to change button text of a completion button
    private void SetCompleteText()
    {
        if (PlayerPrefs.HasKey("Level2Complete"))
        {
            Level2 = PlayerPrefs.GetInt("Level2Complete") == 1 ? true : false;
            if (Level2) { ButtonText.text = "Level 2 gehaald: TRUE"; }
            else if (!Level2) { ButtonText.text = "Level 2 gehaald: FALSE"; }
        }
        else { ButtonText.text = "Level 2 gehaald: FALSE"; }
    }

    // Function to change the status of the level 2 checkpoint
    public void ChangeCheckpointState()
    {
        if (PlayerPrefs.HasKey("Checkpoint1"))
        {
            Level2CP = PlayerPrefs.GetInt("Checkpoint1") == 1 ? true : false;
            if (Level2CP)
            {
                PlayerPrefs.SetInt("Checkpoint1", 0);
                SetCheckpointText();
            }
            else if (!Level2CP)
            {
                PlayerPrefs.SetInt("Checkpoint1", 1);
                SetCheckpointText();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Checkpoint1", 1);
            SetCheckpointText();
        }
    }

    // Function to change button text of a checkpoint button
    private void SetCheckpointText()
    {
        if (PlayerPrefs.HasKey("Checkpoint1"))
        {
            Level2CP = PlayerPrefs.GetInt("Checkpoint1") == 1 ? true : false;
            if (Level2CP) { ButtonText.text = "Level 2 checkpoint: TRUE"; }
            else if (!Level2CP) { ButtonText.text = "Level 2 checkpoint: FALSE"; }
        }
        else { ButtonText.text = "Level 2 checkpoint: FALSE"; }
    }

    // Function to hard reset level 2
    public void HardResetL2()
    {
        if (PlayerPrefs.HasKey("Level2Complete")) { PlayerPrefs.DeleteKey("Level2Complete"); }
        if (PlayerPrefs.HasKey("DidPuzzle")) { PlayerPrefs.DeleteKey("DidPuzzle"); }
        if (PlayerPrefs.HasKey("Checkpoint1")) { PlayerPrefs.DeleteKey("Checkpoint1"); }
        if (PlayerPrefs.HasKey("StopShowingL2Checkpoint")) { PlayerPrefs.DeleteKey("StopShowingL2Checkpoint"); }
        if (PlayerPrefs.HasKey("StopShowingL2Secret")) { PlayerPrefs.DeleteKey("StopShowingL2Secret"); }
        Debug.Log("Level 2 was hard reset, restarting the scene you are currently in is recommended.");
    }
}
