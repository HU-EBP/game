using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyTutorial : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPopUp;
    [SerializeField] private GameObject NextTutorial;
    [SerializeField] private GameObject EnemyObject;
    [SerializeField] private Tilemap ItemTilemap;

    void Start()
    {
        EnemyPopUp.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!EnemyObject.activeSelf)
        {
            ItemTilemap.SetTile(new Vector3Int(45, -1, 0), null);
            ItemTilemap.SetTile(new Vector3Int(45, -2, 0), null);
            ItemTilemap.SetTile(new Vector3Int(45, -3, 0), null);
            ItemTilemap.SetTile(new Vector3Int(45, -4, 0), null);

            EnemyPopUp.gameObject.SetActive(false);
            NextTutorial.gameObject.SetActive(true);
            PlayerPrefs.SetInt("EnemyTutorial", 1);
            enabled = false;
        }
    }
}