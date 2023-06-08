using UnityEngine;

public class HackingTutorial : MonoBehaviour
{
    [SerializeField] private GameObject HackingPopUp;
    [SerializeField] private GameObject FinishPopUp;
    [SerializeField] private GameObject Door;

    void Start()
    {
        HackingPopUp.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Door.transform.position.y == 2)
        {
            HackingPopUp.gameObject.SetActive(false);
            FinishPopUp.gameObject.SetActive(true);
            enabled = false;
        }
    }
}