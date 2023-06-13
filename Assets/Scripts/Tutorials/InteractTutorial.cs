using UnityEngine;

public class InteractTutorial : MonoBehaviour
{
    [SerializeField] private GameObject InteractPopUp;
    [SerializeField] private GameObject NextTutorial;

    void Start()
    {
        InteractPopUp.gameObject.SetActive(true);
    }

    /*private void Update()
    {
        InteractPopUp.gameObject.SetActive(false);
        NextTutorial.gameObject.SetActive(true);
        enabled = false;
    }*/
}