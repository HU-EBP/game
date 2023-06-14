using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Start : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Level1Active")) { PlayerPrefs.DeleteKey("Level1Active"); }
        else if (PlayerPrefs.HasKey("Level3Active")) { PlayerPrefs.DeleteKey("Level3Active"); }

        PlayerPrefs.SetInt("Level2Active", 1);
    }
}