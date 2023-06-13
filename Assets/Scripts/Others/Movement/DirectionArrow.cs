using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float[] switchXValues;
    [SerializeField] private float[] switchYValues;
    [SerializeField] private Transform[] targets;
    [SerializeField] private int switchDirectionIndex;

    private int currentTargetIndex = 0;
    private Transform playerTransform;
    private bool movingRight = true;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player character not found. Make sure to tag the player GameObject as 'Player'.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            arrow.SetActive(!arrow.activeSelf);
            if (arrow.activeSelf)
            {
                UpdateArrowRotation();
            }
        }

        if (playerTransform != null)
        {
            if (movingRight)
            {
                if (playerTransform.position.x > switchXValues[currentTargetIndex] && playerTransform.position.y < switchYValues[currentTargetIndex])
                {
                    currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
                }
            }
            else
            {
                if (playerTransform.position.x < switchXValues[currentTargetIndex] && playerTransform.position.y > switchYValues[currentTargetIndex])
                {
                    currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
                }
            }

            if (currentTargetIndex > switchDirectionIndex)
            {
                movingRight = false;
            }
        }
    }

    private void LateUpdate()
    {
        if (arrow.activeSelf)
        {
            UpdateArrowRotation();
        }
    }

    private void UpdateArrowRotation()
    {
        if (targets.Length == 0 || playerTransform == null)
            return;

        Vector3 direction = (targets[currentTargetIndex].position - playerTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
