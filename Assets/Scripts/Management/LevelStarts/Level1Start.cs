using UnityEngine;

public class Level1Start : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Level2Active")) { PlayerPrefs.DeleteKey("Level2Active"); }
        else if (PlayerPrefs.HasKey("Level3Active")) { PlayerPrefs.DeleteKey("Level3Active"); }

        PlayerPrefs.SetInt("Level1Active", 1);
        enabled = false;
    }
}