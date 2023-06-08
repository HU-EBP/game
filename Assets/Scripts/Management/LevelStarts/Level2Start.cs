using UnityEngine;

public class Level2Start : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Level1Active"))
        {
            PlayerPrefs.DeleteKey("Level1Active");
        }

        PlayerPrefs.SetInt("Level2Active", 1);
        enabled = false;
    }
}