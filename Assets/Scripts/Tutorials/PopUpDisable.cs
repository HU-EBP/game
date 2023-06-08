using UnityEngine;
using System.Collections;

public class PopUpDisable : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    private void Start()
    {
        StartCoroutine(DisableAfterDelay(10f));
    }

    private IEnumerator DisableAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}