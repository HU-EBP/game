using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTester : MonoBehaviour
{
    private List<NodeCheck> buttonList = new List<NodeCheck>();
    private List<NodeCheck> endNodeList = new List<NodeCheck>();
    private NodeCheck[] nodeCheckList;
    private bool[] foundSequence;
    private bool[] originalSequence;
    private bool isPossible = false;

    void Start()
    {
        // Get all NodeCheck components
        nodeCheckList = FindObjectsOfType<NodeCheck>();

        // Separate buttons and end nodes
        foreach (NodeCheck script in nodeCheckList)
        {
            if (script.SelectedNodeType == NodeCheck.NodeType.BUTTON) { buttonList.Add(script); }
            else if (script.SelectedNodeType == NodeCheck.NodeType.END) { endNodeList.Add(script); }
        }

        // Initializing arrays
        foundSequence = new bool[buttonList.Count];
        originalSequence = new bool[buttonList.Count];

        // Set original sequence of buttons on/off
        for (int i = 0; i < buttonList.Count; i++) { originalSequence[i] = buttonList[i].IsPowered; }

        // Log how many possible sequences the current puzzle has
        Debug.Log("This puzzle has " + (Math.Pow(2, buttonList.Count)) + " possible sequences.", gameObject);
    }

    // Main function to check all possible sequences
    private void CheckSequences(int index)
    {
        if (index >= buttonList.Count)
        {
            for (int i = 0; i < buttonList.Count; i++) { buttonList[i].ClickCheck(); }

            bool allTrue = CheckAllVariablesTrue(endNodeList);
            if (allTrue)
            {
                for (int i = 0; i < buttonList.Count; i++) { foundSequence[i] = buttonList[i].IsPowered; }
                string logMessage = string.Join(", ", foundSequence);
                Debug.Log("FOUND all end node correct sequence: " + logMessage, gameObject);
                isPossible = true;
            }

            return;
        }

        buttonList[index].IsPowered = true;
        CheckSequences(index + 1);

        buttonList[index].IsPowered = false;
        CheckSequences(index + 1);
    }

    // Helper function to check if all end nodes are true
    private bool CheckAllVariablesTrue(List<NodeCheck> list)
    {
        foreach (NodeCheck item in list) { if (!item.IsPowered) { return false; } }
        return true;
    }

    void Update()
    {
        // Check for sequences on T key press
        if (Input.GetKeyDown(KeyCode.T))
        {
            CheckSequences(0);
            if (!isPossible)
            {
                for (int i = 0; i < buttonList.Count; i++) { buttonList[i].IsPowered = originalSequence[i]; buttonList[i].ClickCheck(); }
                Debug.LogWarning("Unable to find any valid sequences. If you want the puzzle to be solvable, you will need to modify it.");
            }
            else
            {
                for (int i = 0; i < buttonList.Count; i++) { buttonList[i].IsPowered = foundSequence[i]; buttonList[i].ClickCheck(); }
                isPossible = false;
            }
        }
    }
}