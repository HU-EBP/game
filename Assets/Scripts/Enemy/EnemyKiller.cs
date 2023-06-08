using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 1f;  // Distance to cast the raycast
    [SerializeField] private LayerMask enemyLayer;  // Layer mask for the enemy object
    [SerializeField] private MonoBehaviour DeathScript;

    void Update()
    {
        // Cast a raycast downwards to check if the player is on top of an enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, enemyLayer);

        // If the raycast hit an enemy, destroy the enemy game object and play the death effect
        if (hit.collider != null)
        {
            DeathScript.enabled = false;
            hit.collider.gameObject.SetActive(false);
        }
    }
}