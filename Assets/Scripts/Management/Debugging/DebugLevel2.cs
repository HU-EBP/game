using UnityEngine;
using TMPro;

public class DebugLevel2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ButtonText;
    private bool Level1 = false;

    private void Start()
    {
        SetButtonText();
    }

    public void OnButtonClick()
    {
        if (PlayerPrefs.HasKey("Level2Complete"))
        {
            Level1 = PlayerPrefs.GetInt("Level2Complete") == 1 ? true : false;
            if (Level1)
            {
                PlayerPrefs.SetInt("Level2Complete", 0);
                SetButtonText();
            }
            else if (!Level1)
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

    private void SetButtonText()
    {
        if (PlayerPrefs.HasKey("Level2Complete"))
        {
            Level1 = PlayerPrefs.GetInt("Level2Complete") == 1 ? true : false;
            if (Level1)
            {
                ButtonText.text = "Level 2 gehaald: TRUE";
            }
            else if (!Level1)
            {
                ButtonText.text = "Level 2 gehaald: FALSE";
            }
        }
        else
        {
            ButtonText.text = "Level 2 gehaald: FALSE";
        }
    }
}
