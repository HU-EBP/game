using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartDelayed : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(RestartAfterDelay(5f));
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}