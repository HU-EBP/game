using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class WalkTutorial : MonoBehaviour
{
    [SerializeField] private GameObject WalkPopUp;
    [SerializeField] private GameObject NextTutorial;
    [SerializeField] private Tilemap ItemTilemap;

    [SerializeField] private Renderer AKey;
    [SerializeField] private Renderer DKey;

    private float ATimer = 0;
    private float DTimer = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { ATimer += Time.deltaTime; }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { DTimer += Time.deltaTime; }

        if (ATimer >= 1) { AKey.material.color = new Color(0.5f, 1f, 0.5f); }
        if (DTimer >= 1) { DKey.material.color = new Color(0.5f, 1f, 0.5f); }

        if (ATimer >= 2f) { AKey.material.color = Color.green; }
        if (DTimer >= 2f) { DKey.material.color = Color.green; }

        if (ATimer >= 2f && DTimer >= 2f)
        {
            ItemTilemap.SetTile(new Vector3Int(9, -1, 0), null);
            ItemTilemap.SetTile(new Vector3Int(9, -2, 0), null);
            ItemTilemap.SetTile(new Vector3Int(9, -3, 0), null);
            ItemTilemap.SetTile(new Vector3Int(9, -4, 0), null);

            WalkPopUp.gameObject.SetActive(false);
            NextTutorial.gameObject.SetActive(true);
            PlayerPrefs.SetInt("WalkTutorial", 1);
            enabled = false;
        }
    }
}