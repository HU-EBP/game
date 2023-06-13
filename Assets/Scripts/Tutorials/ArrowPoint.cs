using UnityEngine;

public class ArrowPoint : MonoBehaviour
{
    [SerializeField] private float moveDuration = 0.5f;

    private bool moveUp = false;
    private Vector3 StartPosition;
    private Vector3 UpPosition;
    private float startTime;

    void Start()
    {
        StartPosition = transform.localPosition;
        UpPosition = new Vector3(StartPosition.x, (StartPosition.y + 0.1f), StartPosition.z);
        startTime = Time.time;
    }

    void Update()
    {
        if (moveUp)
        {
            float t = (Time.time - startTime) / moveDuration;
            transform.localPosition = Vector3.Lerp(StartPosition, UpPosition, t);
            if (t >= 1.0f) { startTime = Time.time; moveUp = false; }
        }
        else
        {
            float t = (Time.time - startTime) / moveDuration;
            transform.localPosition = Vector3.Lerp(UpPosition, StartPosition, t);
            if (t >= 1.0f) { startTime = Time.time; moveUp = true; }
        }
    }
}