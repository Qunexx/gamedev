using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = 0.1f;
    public LayerMask collisionMask;
    public float damage = 10f;

    private Vector2 velocity;
    private float distanceTravelled;
    private bool isMoving = true;

    private void Start()
    {
        velocity = transform.right * speed;
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }

        Vector2 deltaPosition = velocity * Time.deltaTime;
        distanceTravelled += deltaPosition.magnitude;
        transform.Translate(deltaPosition, Space.World);

        velocity.y -= gravity * Time.deltaTime;

        CheckCollisions(deltaPosition);
    }

    private void CheckCollisions(Vector2 deltaPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity.normalized, deltaPosition.magnitude, collisionMask);
        if (hit.collider != null)
        {
            isMoving = false;
            transform.position = hit.point;

            // Handle collision logic based on the tag of the hit object
            if (hit.collider.CompareTag("Enemy"))
            {
                // Apply damage to enemy
                EnemyBehavior enemy = hit.collider.GetComponent<EnemyBehavior>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            else if (hit.collider.CompareTag("Obstacle"))
            {
                // Play particle effect
                ParticleSystem particles = hit.collider.GetComponent<ParticleSystem>();
                if (particles != null)
                {
                    particles.Play();
                }
            }

            // Destroy the bullet after a short delay
            Destroy(gameObject, 0.1f);
        }
    }
}
