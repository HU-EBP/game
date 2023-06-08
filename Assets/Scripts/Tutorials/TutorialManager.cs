using UnityEngine;
using UnityEngine.Tilemaps;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Tilemap ItemTilemap;

    [SerializeField] private GameObject WalkPopUp;
    [SerializeField] private GameObject JumpPopUp;
    [SerializeField] private GameObject EnemyPopUp;

    [SerializeField] private GameObject WalkTutorialBox;
    [SerializeField] private GameObject JumpTutorialBox;
    [SerializeField] private GameObject EnemyTutorialBox;
    [SerializeField] private GameObject InteractionTutorialBox;

    private bool WalkTutorial = false;
    private bool JumpTutorial = false;
    private bool EnemyTutorial = false;

    void Start()
    {
        if (PlayerPrefs.HasKey("WalkTutorial")) { WalkTutorial = PlayerPrefs.GetInt("WalkTutorial") == 1 ? true : false; }
        if (PlayerPrefs.HasKey("JumpTutorial")) { JumpTutorial = PlayerPrefs.GetInt("JumpTutorial") == 1 ? true : false; }
        if (PlayerPrefs.HasKey("EnemyTutorial")) { EnemyTutorial = PlayerPrefs.GetInt("EnemyTutorial") == 1 ? true : false; }

        if (WalkTutorial)
        {
            ItemTilemap.SetTile(new Vector3Int(9, -1, 0), null);
            ItemTilemap.SetTile(new Vector3Int(9, -2, 0), null);
            ItemTilemap.SetTile(new Vector3Int(9, -3, 0), null);
            ItemTilemap.SetTile(new Vector3Int(9, -4, 0), null);

            WalkTutorialBox.gameObject.SetActive(false);
            WalkPopUp.gameObject.SetActive(false);
            JumpTutorialBox.gameObject.SetActive(true);
        }

        if (JumpTutorial)
        {
            ItemTilemap.SetTile(new Vector3Int(34, -1, 0), null);
            ItemTilemap.SetTile(new Vector3Int(34, -2, 0), null);
            ItemTilemap.SetTile(new Vector3Int(34, -3, 0), null);
            ItemTilemap.SetTile(new Vector3Int(34, -4, 0), null);

            JumpTutorialBox.gameObject.SetActive(false);
            JumpPopUp.gameObject.SetActive(false);
            EnemyTutorialBox.gameObject.SetActive(true);
        }

        if (EnemyTutorial)
        {
            ItemTilemap.SetTile(new Vector3Int(45, -1, 0), null);
            ItemTilemap.SetTile(new Vector3Int(45, -2, 0), null);
            ItemTilemap.SetTile(new Vector3Int(45, -3, 0), null);
            ItemTilemap.SetTile(new Vector3Int(45, -4, 0), null);

            EnemyTutorialBox.gameObject.SetActive(false);
            EnemyPopUp.gameObject.SetActive(false);
            InteractionTutorialBox.gameObject.SetActive(true);
        }
    }
}