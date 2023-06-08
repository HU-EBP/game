using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private Vector3 teleportPosition;
    private bool Checkpoint1 = false;

    void Start()
    {
        if (PlayerPrefs.HasKey("Checkpoint1"))
        {
            Checkpoint1 = PlayerPrefs.GetInt("Checkpoint1") == 1 ? true : false;
        }

        if (Checkpoint1)
        {
            player.transform.position = teleportPosition;
            camera.transform.position = teleportPosition;
        }
    }
}