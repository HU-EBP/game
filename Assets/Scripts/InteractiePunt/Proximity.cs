using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Proximity : MonoBehaviour
{
    [SerializeField] private GameObject PlayerCharacter;
    [SerializeField] private GameObject TargetObject;
    [SerializeField] private int PuzzleSceneInt;
    [SerializeField] private float activationDistance = 5f;
    [SerializeField] private bool isActive = false;

    private void Update()
    {
        if (!isActive && Vector3.Distance(TargetObject.transform.position, PlayerCharacter.transform.position) <= activationDistance)
        {
            TargetObject.gameObject.SetActive(true);
            isActive = true;
        }
        else if (isActive && Vector3.Distance(TargetObject.transform.position, PlayerCharacter.transform.position) > activationDistance)
        {
            TargetObject.gameObject.SetActive(false);
            isActive = false;
        }

        if (isActive && Input.GetKeyDown(KeyCode.E)) { SceneManager.LoadScene(PuzzleSceneInt); }
    }
}