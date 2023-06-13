using UnityEngine;

public class DebugHometown : MonoBehaviour
{
    // Function to hard reset Hometown
    public void HardResetHT()
    {
        if (PlayerPrefs.HasKey("StopShowingHTWalkTutorial")) { PlayerPrefs.DeleteKey("StopShowingHTWalkTutorial"); }
        Debug.Log("Hometown was hard reset, restarting the scene you are currently in is recommended.");
    }
}