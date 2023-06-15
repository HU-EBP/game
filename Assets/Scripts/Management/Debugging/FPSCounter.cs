using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private float fps = 0.0f;
    private GUIStyle style;

    private void Start()
    {
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperRight;  // Changed alignment to top-right
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        InvokeRepeating("UpdateFPS", 1.0f, 1.0f);
    }

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    private void UpdateFPS()
    {
        fps = 1.0f / deltaTime;
    }

    private void OnGUI()
    {
        string text = $"FPS: {Mathf.RoundToInt(fps)}";

        // Calculate the position based on screen width and height
        float x = Screen.width - 110;
        float y = 10;

        GUI.Label(new Rect(x, y, 100, 20), text, style);
    }
}