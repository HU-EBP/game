using UnityEngine;

public class SecretProx : MonoBehaviour
{
    [SerializeField] private float detectionDistance = 5f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject secretPopUp;

    private bool secretFound;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= detectionDistance)
        {
            secretPopUp.SetActive(true);
            secretFound = true;
        }

        if (secretFound)
        {
            enabled = false;
        }
    }
}