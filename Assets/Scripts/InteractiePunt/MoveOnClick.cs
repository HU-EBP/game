using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    [SerializeField] private GameObject InteractionBox;
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private Vector3 moveTo;

    private bool isMoving = false;
    private float startTime;
    private Vector3 startPosition;

    public void OnButtonClick()
    {
        if (!isMoving)
        {
            isMoving = true;
            startTime = Time.time;
            startPosition = objectToMove.localPosition;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            float t = (Time.time - startTime) / moveDuration;
            objectToMove.localPosition = Vector3.Lerp(startPosition, moveTo, t);
            if (t >= 1.0f)
            {
                isMoving = false;
                InteractionBox.gameObject.SetActive(false);
            }
        }
    }
}