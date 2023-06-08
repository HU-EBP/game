using UnityEngine;

public class RestartConfirm : MonoBehaviour
{
    [SerializeField] private GameObject ConfirmationBox;

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ConfirmationBox.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}