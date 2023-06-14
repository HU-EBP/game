using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeybindManager : MonoBehaviour
{
    // Dictionary to store the keybinds
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

private bool isRebinding = false;

    // Bool to check if a key is being rebound
    public bool IsRebinding
{
    get { return isRebinding; }
}


    // Button references for the UI
    public Button upKeyBind;
    public Button downKeyBind;
    public Button leftKeyBind;
    public Button rightKeyBind;
    public Button jumpKeyBind;
    public Button restartLevelKeyBind;
    public Button interactKeyBind;
    public Button menuKeyBind; // Added Menu KeyBind

    private Button currentButton;

    void Start()
    {
        // Add default keybinds to the dictionary
        keys.Add("Up", KeyCode.UpArrow);
        keys.Add("Down", KeyCode.DownArrow);
        keys.Add("Left", KeyCode.LeftArrow);
        keys.Add("Right", KeyCode.RightArrow);
        keys.Add("Jump", KeyCode.Space);
        keys.Add("RestartLevel", KeyCode.R);
        keys.Add("Interact", KeyCode.E);
        keys.Add("Menu", KeyCode.Escape); // Added Menu KeyBind

        // Load the saved keybinds or set them to default values
        LoadKeybinds();

        // Update button text to display the current keybinds
        UpdateButtonText();

        // Add listeners to each button to handle clicks and start rebinding
        upKeyBind.onClick.AddListener(() => StartRebinding("Up", upKeyBind));
        downKeyBind.onClick.AddListener(() => StartRebinding("Down", downKeyBind));
        leftKeyBind.onClick.AddListener(() => StartRebinding("Left", leftKeyBind));
        rightKeyBind.onClick.AddListener(() => StartRebinding("Right", rightKeyBind));
        jumpKeyBind.onClick.AddListener(() => StartRebinding("Jump", jumpKeyBind));
        restartLevelKeyBind.onClick.AddListener(() => StartRebinding("RestartLevel", restartLevelKeyBind));
        interactKeyBind.onClick.AddListener(() => StartRebinding("Interact", interactKeyBind));
        menuKeyBind.onClick.AddListener(() => StartRebinding("Menu", menuKeyBind)); // Added Menu KeyBind listener
    }

    private void UpdateButtonText()
    {
        upKeyBind.GetComponentInChildren<TextMeshProUGUI>().text = keys["Up"].ToString();
        downKeyBind.GetComponentInChildren<TextMeshProUGUI>().text = keys["Down"].ToString();
        leftKeyBind.GetComponentInChildren<TextMeshProUGUI>().text = keys["Left"].ToString();
        rightKeyBind.GetComponentInChildren<TextMeshProUGUI>().text = keys["Right"].ToString();
        jumpKeyBind.GetComponentInChildren<TextMeshProUGUI>().text = keys["Jump"].ToString();
        restartLevelKeyBind.GetComponentInChildren<TextMeshProUGUI>().text = keys["RestartLevel"].ToString();
        interactKeyBind.GetComponentInChildren<TextMeshProUGUI>().text = keys["Interact"].ToString();
        menuKeyBind.GetComponentInChildren<TextMeshProUGUI>().text = keys["Menu"].ToString(); // Update Menu KeyBind text
    }

    private void LoadKeybinds()
    {
        List<string> tempKeys = new List<string>(keys.Keys);

        foreach (string key in tempKeys)
        {
            if (PlayerPrefs.HasKey(key))
            {
                KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(key));
                keys[key] = keyCode;
            }
            else
            {
                PlayerPrefs.SetString(key, keys[key].ToString());
            }
        }
    }

   private void StartRebinding(string key, Button button)
{
    currentButton = button;
    currentButton.GetComponentInChildren<TextMeshProUGUI>().text = "Choose key...";
    isRebinding = true; // Set isRebinding to true
    StartCoroutine(WaitForKeyPress(key));
}


// Coroutine to wait for a key press
private IEnumerator WaitForKeyPress(string key)
{
    while (!Input.anyKeyDown)
    {
        yield return null;
    }

    // Find the key that was pressed
    foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
    {
        if (Input.GetKeyDown(keyCode))
        {
            // Update the keybind and save it
            keys[key] = keyCode;
            PlayerPrefs.SetString(key, keyCode.ToString());
            break;
        }
    }

    // Update the button text and set currentButton back to null
    currentButton.GetComponentInChildren<TextMeshProUGUI>().text = keys[key].ToString();
    currentButton = null;
    isRebinding = false; // Set isRebinding back to false
}

}