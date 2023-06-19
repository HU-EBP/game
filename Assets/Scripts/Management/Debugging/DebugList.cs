 using UnityEngine;
using System.Collections.Generic;

public class DebugList : MonoBehaviour
{
    private List<string> logMessages = new List<string>();
    private Vector2 scrollPosition = Vector2.zero;
    private GUIStyle boxStyle;

    // Disable/enable displaying log messages when debug menu is disabled/enabled
    private void OnEnable() { Application.logMessageReceived += HandleLogMessage; }
    private void OnDisable() { Application.logMessageReceived -= HandleLogMessage; }
    private void HandleLogMessage(string logString, string stackTrace, LogType type) { logMessages.Add(logString); }

    // Get log message list
    private void OnGUI()
    {
        // Make a box to hold the list
        const float boxWidth = 300f;
        const float boxHeight = 1020f;
        Rect boxRect = new Rect(Screen.width - boxWidth - 10f, 60f, boxWidth, boxHeight);

        // Style for each individual list item
        if (boxStyle == null)
        {
            boxStyle = new GUIStyle(GUI.skin.box);
            boxStyle.wordWrap = true;
            boxStyle.fontSize = 20;
            Color backgroundColor = new Color(0f, 0f, 0f, 1f);
            Texture2D backgroundTexture = new Texture2D(1, 1);
            backgroundTexture.SetPixel(0, 0, backgroundColor);
            backgroundTexture.Apply();
            boxStyle.normal.background = backgroundTexture;
        }

        // Initializing the box
        GUILayout.BeginArea(boxRect);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        GUILayout.BeginVertical();

        // Putting each message in its own box
        foreach (var message in logMessages)
        {
            GUILayout.Box(message, boxStyle, GUILayout.ExpandWidth(true));
            GUILayout.Space(5f);
        }

        // Stop initializing the box
        GUILayout.EndVertical();
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
}