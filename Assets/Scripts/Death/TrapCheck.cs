using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrapCheck : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator PlayerAnimator;

    private IEnumerator coroutine;
    private CapsuleCollider2D playerCollision;
    private Rigidbody2D playerRigidbody2D;
    private MonoBehaviour ScriptToDisable1;
    private MonoBehaviour ScriptToDisable2;

    void Start()
    {
        playerCollision = player.GetComponent<CapsuleCollider2D>();
        playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        ScriptToDisable1 = player.GetComponent<MoveSide>();
        ScriptToDisable2 = player.GetComponent<EnemyKiller>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerAnimator.SetBool("IsDead", true);
            playerCollision.enabled = false;
            playerRigidbody2D.isKinematic = true;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
            ScriptToDisable1.enabled = false;
            ScriptToDisable2.enabled = false;
            StartCoroutine(WaitForAnimation());
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}