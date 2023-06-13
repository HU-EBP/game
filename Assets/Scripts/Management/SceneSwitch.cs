using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int SceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // If the scene to load is level 2, check if level 1 was completed first
            if (SceneToLoad == 3)
            {
                if (PlayerPrefs.HasKey("Level1Complete"))
                {
                    if (PlayerPrefs.GetInt("Level1Complete") == 1)
                    {
                        SceneManager.LoadScene(SceneToLoad);
                    }
                }
            }
            else
            {
                SceneManager.LoadScene(SceneToLoad);
            }
        }
    }
}