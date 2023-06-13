using UnityEngine;

public class PopUp : MonoBehaviour
{
    public float speed = 5f; // Speed at which the object moves
    public RectTransform rectTransform; // Reference to the RectTransform component that will be moved
    public float distanceToMove = 10f; // Distance to move the object to the right
    public float delay = 1f; // Delay before the object starts moving
    private Vector2 startPosition; // Starting position of the object
    private bool start = false;

    private void Start()
    {
        if (rectTransform == null)
        {
            Debug.LogWarning("No RectTransform found on " + gameObject.name);
            enabled = false;
            return;
        }

        startPosition = rectTransform.anchoredPosition;

        // Call the MoveObject() function after the specified delay
        Invoke("MoveObject", delay);
    }

    private void MoveObject()
    {
        // Enable this script to start moving the object
        start = true;
    }

    private void Update()
    {
        if (start)
        {
            // Move the object to the right
            rectTransform.anchoredPosition += new Vector2((speed * 100) * Time.deltaTime, 0f);

            // If the object has moved the desired distance to the right, disable this script
            if (rectTransform.anchoredPosition.x >= startPosition.x + distanceToMove)
            {
                enabled = false;
            }
        }
    }
}