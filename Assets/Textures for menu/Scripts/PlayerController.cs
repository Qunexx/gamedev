using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


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

    //Реализация нажатия кнопок движения на андроиде
    public bool onLeftBtn = false;
    public bool onRightBtn = false;
    public bool onJumpBtn = false;

    public GameObject DeathInterface; 
    private bool isDied = false; //игрок умер?



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || onLeftBtn)
        {
            movingLeft = true;
            movingRight = false;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D)|| onRightBtn)
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
        
        if ((Input.GetKeyDown(KeyCode.Space) || onJumpBtn) && jumpCount < maxJumps && isGrounded == true)
        {
            onJumpBtn = false;
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
        
        if (isDied) return;
        health -= damage;
        if (health <= 0f)
        {
            isDied = true;
            Die();
        }
    }

    private void Die()
    {   
        ShowDeathScreen();// Handle player death here
            this.gameObject.SetActive(false); //Чтоб не удалялся перс
            //Destroy(gameObject);
        
    }

    private void ShowDeathScreen() //показывает экран смерти
    {
        Debug.Log(DeathInterface.name);
        DeathInterface.SetActive(true);
        fade();

    }

    public async void fade()
    {   
        var newColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        var DeathInterfaceImage = DeathInterface.GetComponent<Image>();
        DeathInterfaceImage.color = newColor;

        

        while (newColor.a < 0.9f)
        {
            newColor.a = newColor.a + 0.05f;

            await Task.Delay(100);

            DeathInterfaceImage.color = newColor;
        }

    }
    public void jumpclick()
    {
        onJumpBtn=true;

    }


}