using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTypes : MonoBehaviour
{
    public GameObject ArrowsObject;
    public GameObject WASDObject;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) { ArrowsObject.SetActive(false); WASDObject.SetActive(true); }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) { ArrowsObject.SetActive(true); WASDObject.SetActive(false); }
    }
}