using UnityEngine;

public class CompleteCheck : MonoBehaviour
{
    [SerializeField] private NodeCheck[] EndNodes;
    [SerializeField] private PuzzleManager MainPuzzleManager;
    private bool AllPowered = false;

    void Update()
    {
        for (int i = 0; i < EndNodes.Length; i++)
        {
            NodeCheck ScriptHolder = EndNodes[i].GetComponent<NodeCheck>();
            if (!ScriptHolder.IsPowered) { AllPowered = false; break; }
            else { AllPowered = true; }
        }

        PuzzleManager ScriptHolder2 = MainPuzzleManager.GetComponent<PuzzleManager>();
        ScriptHolder2.IsCompleted = AllPowered;
        ScriptHolder2.DoCheck();
    }
}
