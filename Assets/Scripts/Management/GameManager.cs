using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private Vector3 teleportPosition;
    private bool Checkpoint1 = false;
    private bool DidPuzzle = false;

    void Start()
    {
        if (PlayerPrefs.HasKey("DidPuzzle"))
        {
            DidPuzzle = PlayerPrefs.GetInt("DidPuzzle") == 1 ? true : false;
            PlayerPrefs.DeleteKey("DidPuzzle");
        }

        // Get checkpoint reached value
        if (PlayerPrefs.HasKey("Checkpoint1")) { Checkpoint1 = PlayerPrefs.GetInt("Checkpoint1") == 1 ? true : false; }

        if (!DidPuzzle && Checkpoint1)
        {
            player.transform.position = teleportPosition;
            camera.transform.position = teleportPosition;
        }
    }
}