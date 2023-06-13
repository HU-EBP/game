using UnityEngine;

public class InteractTutorial : MonoBehaviour
{
    [SerializeField] private GameObject InteractPopUp;
    [SerializeField] private GameObject NextTutorial;
    [SerializeField] private int PuzzleInt = 1;

    void Start()
    {
        InteractPopUp.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("Puzzle" + PuzzleInt + "Completed"))
        {
            if (PlayerPrefs.GetInt("Puzzle" + PuzzleInt + "Completed") == 1)
            {
                InteractPopUp.gameObject.SetActive(false);
                NextTutorial.gameObject.SetActive(true);
                enabled = false;
            }
        }
    }
}