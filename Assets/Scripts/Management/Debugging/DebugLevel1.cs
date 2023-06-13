using UnityEngine;
using TMPro;

public class DebugLevel1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ButtonText;
    [SerializeField] private bool IsCompleteButton = false;
    private bool Level1 = false;

    private void Start() { if (IsCompleteButton) { SetButtonText(); } }

    // Function to change the completion status of level 1
    public void ChangeCompleteState()
    {
        if (PlayerPrefs.HasKey("Level1Complete"))
        {
            Level1 = PlayerPrefs.GetInt("Level1Complete") == 1 ? true : false;
            if (Level1)
            {
                PlayerPrefs.SetInt("Level1Complete", 0);
                SetButtonText();
            }
            else if (!Level1)
            {
                PlayerPrefs.SetInt("Level1Complete", 1);
                SetButtonText();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level1Complete", 1);
            SetButtonText();
        }
    }

    // Function to change button text of a completion button
    private void SetButtonText()
    {
        if (PlayerPrefs.HasKey("Level1Complete"))
        {
            Level1 = PlayerPrefs.GetInt("Level1Complete") == 1 ? true : false;
            if (Level1) { ButtonText.text = "Level 1 gehaald: TRUE"; }
            else if (!Level1) { ButtonText.text = "Level 1 gehaald: FALSE"; }
        }
        else { ButtonText.text = "Level 1 gehaald: FALSE"; }
    }

    // Function to hard reset level 1
    public void HardResetL1()
    {
        if (PlayerPrefs.HasKey("Level1Complete")) { PlayerPrefs.DeleteKey("Level1Complete"); }
        if (PlayerPrefs.HasKey("WalkTutorial")) { PlayerPrefs.DeleteKey("WalkTutorial"); }
        if (PlayerPrefs.HasKey("JumpTutorial")) { PlayerPrefs.DeleteKey("JumpTutorial"); }
        if (PlayerPrefs.HasKey("EnemyTutorial")) { PlayerPrefs.DeleteKey("EnemyTutorial"); }
        Debug.Log("Level 1 was hard reset, restarting the scene you are currently in is recommended.");
    }
}