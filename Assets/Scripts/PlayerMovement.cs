using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float moveSpeed = 1.7f;
    private Rigidbody2D rb;
    private Vector2 movement;

     void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets input from WASD or Arrow Keys
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        if (moveX < 0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = true; 
        }

        // If the player is moving, trigger walking, otherwise idle
        if (movement != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerIdle"))
            {
                animator.Play("PlayerIdle", 0, 0f); 
            }
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
