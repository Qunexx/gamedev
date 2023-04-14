using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveRange = 3f; // The distance the enemy moves back and forth
    public float moveSpeed = 2f; // The speed at which the enemy moves

    private Vector2 startingPosition;
    private float direction = 1f; // The direction the enemy is currently moving (1 = right, -1 = left)

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        // Move the enemy horizontally back and forth within the move range
        float deltaX = direction * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector2(deltaX, 0f));

        float distanceFromStartingPosition = Mathf.Abs(transform.position.x - startingPosition.x);
        if (distanceFromStartingPosition >= moveRange)
        {
            // Change direction when the enemy reaches the end of the move range
            direction = -direction;
        }
    }
}