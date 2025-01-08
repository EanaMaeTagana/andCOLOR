using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variables
    public float speed = 5f; // player speed
    public float jump = 10f; // player jump force
    public AudioClip jumpSound; // for the jump sound

    private Rigidbody2D rb; // reference to rigidbody for physics
    private bool isGrounded; // checks if player is on the ground
    private AudioSource audioSource; // to play the jump sound

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets the rigidbody
        audioSource = GetComponent<AudioSource>(); // gets the AudioSource component
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal"); // gets the input for horizontal movement (A/D or left/right arrow keys)
        rb.velocity = new Vector2(move * speed, rb.velocity.y); // set the velocity for the movement

        if (Input.GetButtonDown("Jump") && isGrounded) // checks if player is grounded and pressing jump
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse); // applies the jump force 
            
            // if audio source and jump sound is not empty
            if (audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound); // play the jump sound
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // when collider is in contact with another collider
    {
        if (collision.gameObject.CompareTag("Platform")) // checks if player is touching an object tagged as "platform"
        {
            isGrounded = true; // sets as grounded
        }
    }

    void OnCollisionExit2D(Collision2D collision) // when collider stops contact with another collider
    {
        if (collision.gameObject.CompareTag("Platform")) // checks if player has stopped collision with an object tagged as "platform"
        {
            isGrounded = false; // unsets as grounded
        }
    }
}