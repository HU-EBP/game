using UnityEngine;

public class Level1Start : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Level2Active"))
        {
            PlayerPrefs.DeleteKey("Level2Active");
        }

        PlayerPrefs.SetInt("Level1Active", 1);
        enabled = false;
    }
}