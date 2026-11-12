using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float destroyX = -15f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.GetComponent<Player>() != null)
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Die();
            }
        }
    }
}
