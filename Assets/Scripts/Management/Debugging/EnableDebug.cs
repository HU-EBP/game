using UnityEngine;

public class EnableDebug : MonoBehaviour
{
    [SerializeField] private GameObject DebugScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (!DebugScreen.activeSelf)
            {
                Debug.Log("Enabling Debug mode.");
                DebugScreen.SetActive(true);
            }
            else
            {
                Debug.Log("Disabling Debug mode.");
                DebugScreen.SetActive(false);
            }
        }
    }
}
