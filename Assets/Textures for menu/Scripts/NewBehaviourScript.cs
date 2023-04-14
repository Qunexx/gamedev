using UnityEngine;
public class NewBehaviourScript : MonoBehaviour
{
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

    public bool isGround = true;
    public float rayDistance = 0.6f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("car inc"));
        
        if (hit.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        
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
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "car inc")
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "car inc")
        {
            isGrounded = false;
        }
    }
}