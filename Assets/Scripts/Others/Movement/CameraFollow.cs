using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object that the camera should follow
    public float smoothSpeed = 0.125f; // The speed at which the camera moves towards the target
    public Vector3 offset; // The offset of the camera from the target
    public float minimumHeight = -0.25f; // Set the minimum height here
    public float maximumHeight = 10f; // Set the maximum height here
    public float minLeft = -10f;
    public float minRight = 2f;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        float clampedX = Mathf.Clamp(targetPosition.x, minLeft, minRight); // set the X range here
        float clampedY = Mathf.Clamp(targetPosition.y, minimumHeight, maximumHeight); // set the Y range here
        Vector3 desiredPosition = new Vector3(clampedX, clampedY, targetPosition.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}