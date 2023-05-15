using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float detectionDistance = 5f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject checkpointFlag;
    private bool Checkpoint1 = false;
    private Renderer flagRenderer;

    private void Start()
    {
        flagRenderer = checkpointFlag.GetComponent<Renderer>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectionDistance)
        {
            PlayerPrefs.SetInt("Checkpoint1", 1);
            flagRenderer.material.color = new Color(0.25f, 0.25f, 0.25f, 1);
        }

        if (PlayerPrefs.HasKey("Checkpoint1"))
        {
            Checkpoint1 = PlayerPrefs.GetInt("Checkpoint1") == 1 ? true : false;
        }

        if (Checkpoint1)
        {
            enabled = false;
        }
    }
}
