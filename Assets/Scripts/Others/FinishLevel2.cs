using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel2 : MonoBehaviour
{
    [SerializeField] private Transform PlayerCharacter;
    [SerializeField] private float detectionDistance = 5f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, PlayerCharacter.transform.position);

        if (distance <= detectionDistance)
        {
            PlayerPrefs.SetInt("Level2Complete", 1);
            SceneManager.LoadScene(1);
        }
    }
}