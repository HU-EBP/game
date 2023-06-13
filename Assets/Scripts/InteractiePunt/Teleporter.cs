using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private PuzzleCheck[] PuzzleChecks;
    [SerializeField] private Transform[] TeleportPoints;
    [SerializeField] private GameObject PlayerCharacter;
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform CheckpointPos;

    private bool[] PuzzleBools;
    private bool PuzzleDone = false;
    private bool Checkpoint1 = false;

    void Start()
    {
        // Initializing PuzzleBools array
        PuzzleBools = new bool[PuzzleChecks.Length];

        // Get value to check if a puzzle was done (if the player came from the PuzzleScene), remove pref
        if (PlayerPrefs.HasKey("DidPuzzle"))
        {
            PuzzleDone = PlayerPrefs.GetInt("DidPuzzle") == 1;
            PlayerPrefs.DeleteKey("DidPuzzle");
        }

        // Get value to check if a checkpoint was reached
        if (PlayerPrefs.HasKey("Checkpoint1")) { Checkpoint1 = PlayerPrefs.GetInt("Checkpoint1") == 1 ? true : false; }

        // If player did not come from the PuzzleScene
        if (!PuzzleDone && Checkpoint1)
        {
            PlayerCharacter.transform.position = CheckpointPos.transform.position;
            Camera.transform.position = CheckpointPos.transform.position;
        }
        // If player came from the PuzzleScene
        if (PuzzleDone)
        {
            for (int i = 0; i < PuzzleChecks.Length; i++)
            {
                PuzzleCheck ScriptHolder = PuzzleChecks[i].GetComponent<PuzzleCheck>();
                if (ScriptHolder.PuzzleCompleted == true)
                {
                    PlayerCharacter.transform.position = TeleportPoints[i].transform.position;
                    Camera.transform.position = TeleportPoints[i].transform.position;
                    break;
                }
            }
        }
    }
}
