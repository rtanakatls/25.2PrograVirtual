using UnityEngine;

public class LineMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
