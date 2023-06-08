using UnityEngine;

public class DisablePause : MonoBehaviour
{
    [SerializeField] private GameObject thisObject;

    void Update()
    {
        Time.timeScale = 1;
        thisObject.SetActive(false);
    }
}