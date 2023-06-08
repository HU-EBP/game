using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResetConfirm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private GameObject thisGameObject;

    private float timesClicked = 0;

    private void Start()
    {
        textObject.color = Color.red;
        textObject.text = "Resetten?";
        thisGameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (timesClicked == 1)
        {
            textObject.color = new Color(0.196f, 0.196f, 0.196f, 1);
            textObject.text = "Reset level";

            if (PlayerPrefs.HasKey("Level1Active"))
            {
                PlayerPrefs.SetInt("WalkTutorial", 0);
                PlayerPrefs.SetInt("JumpTutorial", 0);
                PlayerPrefs.SetInt("EnemyTutorial", 0);
            }

            if (PlayerPrefs.HasKey("Level2Active"))
            {
                Debug.Log("Level 2 reset");
                PlayerPrefs.SetInt("Checkpoint1", 0);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        timesClicked = 1;
    }
}