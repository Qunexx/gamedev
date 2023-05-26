using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f; // The amount of damage the enemy deals to the player
    public float attackRange = 1f; // The distance at which the enemy can attack the player
    public float attackSpeed = 1f; // The speed at which the enemy attacks the player
    public LayerMask playerLayer; // The layer that the player game object is on

    private Transform playerTransform;
    private float lastAttackTime;


    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (IsPlayerInRange() && CanAttack())
        {
            Attack();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle enemy death here
        Destroy(gameObject);
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        return distanceToPlayer <= attackRange;
    }

    private bool CanAttack()
    {
        float timeSinceLastAttack = Time.time - lastAttackTime;
        return timeSinceLastAttack >= attackSpeed;
    }

    private void Attack()
    {
        // Attack the player here
        PlayerController playerController = playerTransform.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(damage);
        }
        lastAttackTime = Time.time;
    }
}