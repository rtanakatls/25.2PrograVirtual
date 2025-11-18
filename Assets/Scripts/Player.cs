using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody rb;

    private int score
    {
        get
        {
            return GameData.score;
        }
        set
        {
            GameData.score = value;
        }
    }

    private void Awake()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity=Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void ChangeScore(int value)
    {
        score += value;
        ScoreUI.Instance.UpdateScore(score);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Score"))
        {
            ChangeScore(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
