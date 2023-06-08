using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class JumpTutorial : MonoBehaviour
{
    [SerializeField] private GameObject JumpPopUp;
    [SerializeField] private GameObject NextTutorial;
    [SerializeField] private Renderer SpaceKey;
    [SerializeField] private Tilemap ItemTilemap;

    private int JumpCounter;

    void Start()
    {
        JumpPopUp.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) { JumpCounter++; }
        if (JumpCounter == 1) { SpaceKey.material.color = new Color(0.67f, 1f, 0.67f); }
        else if (JumpCounter == 2) { SpaceKey.material.color = new Color(0.33f, 1f, 0.33f); }
        else if (JumpCounter >= 3)
        {
            SpaceKey.material.color = new Color(0f, 1f, 0f);
            ItemTilemap.SetTile(new Vector3Int(34, -1, 0), null);
            ItemTilemap.SetTile(new Vector3Int(34, -2, 0), null);
            ItemTilemap.SetTile(new Vector3Int(34, -3, 0), null);
            ItemTilemap.SetTile(new Vector3Int(34, -4, 0), null);

            JumpPopUp.gameObject.SetActive(false);
            NextTutorial.gameObject.SetActive(true);
            PlayerPrefs.SetInt("JumpTutorial", 1);
            enabled = false;
        }
    }
}