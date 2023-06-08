using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float detectionDistance = 5f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject checkpointTutorial;
    [SerializeField] private GameObject checkpointFlag;
    [SerializeField] private Animator checkpointAnim;

    private bool Checkpoint1 = false;
    private Renderer flagRenderer;

    private void Start()
    {
        flagRenderer = checkpointFlag.GetComponent<Renderer>();
        flagRenderer.material.color = Color.black;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectionDistance)
        {
            flagRenderer.material.color = Color.white;
            checkpointAnim.SetBool("PointReached", true);
            PlayerPrefs.SetInt("Checkpoint1", 1);
            checkpointTutorial.SetActive(true);
        }

        if (PlayerPrefs.HasKey("Checkpoint1"))
        {
            Checkpoint1 = PlayerPrefs.GetInt("Checkpoint1") == 1 ? true : false;
        }

        if (Checkpoint1)
        {
            flagRenderer.material.color = Color.white;
            checkpointAnim.SetBool("PointReached", true);
            enabled = false;
        }
    }
}
