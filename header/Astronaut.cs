using UnityEngine;

public class MoonLanderCharacterPhysics : MonoBehaviour
{
    // Physics parameters
    public float gravity = -1.6f; // Custom gravity to simulate moon-like gravity
    public float jumpForce = 5f; // Jump force
    public float thrustForce = 2f; // Lander thrusters strength
    public float moveSpeed = 2f;  // Character horizontal movement speed

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable Unity's default gravity to use our custom gravity
    }

    private void Update()
    {
        HandleGravity();
        HandleMovement();
        HandleJump();
        HandleThrust();
    }

    // Custom gravity implementation to simulate lunar gravity
    private void HandleGravity()
    {
        if (!isGrounded)
        {
            rb.velocity += new Vector2(0, gravity * Time.deltaTime); // Apply gravity over time
        }
    }

    // Horizontal movement control (left and right)
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal"); // -1 to 1 (left to right)

        // Apply the movement force to the character
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    // Jump functionality when grounded
    private void HandleJump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) // Jump with space key
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply vertical velocity for jump
        }
    }

    // Thrust functionality to simulate thrusters (upward force)
    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.W)) // Hold W for thrust
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y + thrustForce * Time.deltaTime, -Mathf.Infinity, 5f)); // Limit upward velocity
        }
    }

    // Check if the character is touching the ground to determine jump eligibility
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Here we assume any object with a "Ground" tag will be treated as the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detect when the character leaves the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}