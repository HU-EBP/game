using UnityEngine;

public class StopShowing : MonoBehaviour
{
    [SerializeField] private string StopShowingThis;
    private GameObject ThisObject;

    void Start()
    {
        ThisObject = gameObject;
        if (PlayerPrefs.HasKey("StopShowing" + StopShowingThis)) { ThisObject.SetActive(false); }
        else { PlayerPrefs.SetInt("StopShowing" + StopShowingThis, 1); enabled = false; }
    }
}
