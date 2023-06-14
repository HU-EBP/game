using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private GameObject PlayerCharacter;
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform CheckpointPos;

    private bool Checkpoint1 = false;
    private float XPos;
    private float YPos;

    void Start()
    {
        // Get value to check if a checkpoint was reached
        if (PlayerPrefs.HasKey("Checkpoint1")) { Checkpoint1 = PlayerPrefs.GetInt("Checkpoint1") == 1; }

        // If player did not come from the PuzzleScene
        if (!PlayerPrefs.HasKey("TeleportX") && !PlayerPrefs.HasKey("TeleportY") && Checkpoint1)
        {
            PlayerCharacter.transform.position = CheckpointPos.transform.position;
            Camera.transform.position = CheckpointPos.transform.position;
        }
        // If player came from the PuzzleScene
        if (PlayerPrefs.HasKey("TeleportX") && PlayerPrefs.HasKey("TeleportY"))
        {
            XPos = PlayerPrefs.GetFloat("TeleportX");
            YPos = PlayerPrefs.GetFloat("TeleportY");
            PlayerCharacter.transform.position = new Vector3(XPos, YPos, PlayerCharacter.transform.position.z);
            Camera.transform.position = new Vector3(XPos, YPos, Camera.transform.position.z);

            if (PlayerPrefs.HasKey("TeleportX")) { PlayerPrefs.DeleteKey("TeleportX"); }
            if (PlayerPrefs.HasKey("TeleportY")) { PlayerPrefs.DeleteKey("TeleportY"); }
        }
    }
}