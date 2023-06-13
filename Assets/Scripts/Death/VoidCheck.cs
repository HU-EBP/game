using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float minYLevel = 0f;

    private void Update()
    {
        if (playerTransform.position.y < minYLevel)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}