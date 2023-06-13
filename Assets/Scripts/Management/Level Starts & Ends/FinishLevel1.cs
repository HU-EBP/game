using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel1 : MonoBehaviour
{
    [SerializeField] private Transform PlayerCharacter;
    [SerializeField] private float FinishPosition;

    private void Update()
    {
        if (PlayerCharacter.position.x > FinishPosition)
        {
            PlayerPrefs.SetInt("Level1Complete", 1);
            SceneManager.LoadScene(1);
        }
    }
}