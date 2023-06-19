using UnityEngine;

public class EnableDebug : MonoBehaviour
{
    [SerializeField] private GameObject DebugScreen;

    void Update()
    {
        // Enable/disable debug screen on F4
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (!DebugScreen.activeSelf) { DebugScreen.SetActive(true); }
            else { DebugScreen.SetActive(false); }
        }
    }
}
