using UnityEngine;
using TMPro;

public class DebugGodMode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ButtonText;
    [SerializeField] private GameObject TrapCheck;
    [SerializeField] private GameObject PlayerDeath;
    private bool godMode = false;

    private MonoBehaviour TrapCheckScript;
    private MonoBehaviour DeathGoblinScript;

    private void Start()
    {
        SetButtonText();

        TrapCheckScript = TrapCheck.GetComponent<TrapCheck>();
        DeathGoblinScript = PlayerDeath.GetComponent<DeathGoblin>();
    }

    public void OnButtonClick()
    {
        if (godMode)
        {
            if (TrapCheckScript != null) { TrapCheckScript.enabled = true; }
            if (DeathGoblinScript != null) { DeathGoblinScript.enabled = true; }
            godMode = false;
            SetButtonText();
        }
        else if (!godMode)
        {
            if (TrapCheckScript != null) { TrapCheckScript.enabled = false; }
            if (DeathGoblinScript != null) { DeathGoblinScript.enabled = false; }
            godMode = true;
            SetButtonText();
        }
    }

    private void SetButtonText()
    {
        if (godMode)
        {
            ButtonText.text = "God mode: TRUE";
        }
        else if (!godMode)
        {
            ButtonText.text = "God mode: FALSE";
        }
    }
}
