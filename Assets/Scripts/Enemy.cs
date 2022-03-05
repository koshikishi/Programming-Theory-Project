using UnityEngine;

public class Enemy : MonoBehaviour
{
    const float speed = 1f;
    const float maxVelocity = 2f;

    Rigidbody enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.isGameOver && !GameManager.Instance.isGamePaused)
        {
            // Move the enemy towards the player
            Vector3 lookDirection = (PlayerController.Instance.transform.position - transform.position).normalized;
            enemyRb.AddForce(speed * lookDirection);

            // Limit the maximum speed of the enemy
            if (enemyRb.velocity.magnitude > maxVelocity)
            {
                enemyRb.velocity = enemyRb.velocity.normalized * maxVelocity;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Reset the player color to white on collision with the enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.ChangeColor(Color.white);
        }
    }
}
