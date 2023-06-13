using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Animator GoblinAnimator;

    private bool movingToA = false;

    void Update()
    {
        Vector3 targetPosition = movingToA ? pointA.position : pointB.position;
        Vector3 movementDirection = (targetPosition - transform.position).normalized;
        transform.Translate(movementDirection * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingToA = !movingToA;
        }

        if (movingToA) { GoblinAnimator.SetBool("MovingLeft", false);  }
        else { GoblinAnimator.SetBool("MovingLeft", true); }
    }
}