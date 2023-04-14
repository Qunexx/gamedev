using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float health = 100f;
    public float jumpForce = 7.0f;
    public float gravityScale = 1.0f;
    public int maxJumps = 1;

    private Rigidbody2D rb;
    private Animator animator;
    private int jumpCount = 0;
    private bool isGrounded = true;
    private bool isClimbing = false;

    public float moveSpeed = 10f;
    private bool movingLeft = false;
    private bool movingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movingLeft = true;
            movingRight = false;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movingRight = true;
            movingLeft = false;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            movingLeft = false;
            movingRight = false;
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle player death here
        Destroy(gameObject);
    }

}