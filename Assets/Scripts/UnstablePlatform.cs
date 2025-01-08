using UnityEngine;

public class UnstablePlatform : MonoBehaviour
{
    public float breakDelay = 2f; // time before platform breaks
    public float reappearDelay = 5f; // time before the platform reappears

    private bool playerOnPlatform = false; // boolean to check if player is on platform
    private float timer = 0f; // tracks length of time player is on platform

    private SpriteRenderer spriteRenderer; // sprite renderer
    private Collider2D platformCollider; // platform collider

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // gets the sprite for the platform
        platformCollider = GetComponent<Collider2D>(); // gets the collider for the platform
    }

    private void Update()
    {
        if (playerOnPlatform) // if player on platform is true
        {
            timer += Time.deltaTime; // increase the count of the timer

            if (timer >= breakDelay) // if timer exceeds the break
            {
                BreakPlatform(); // triggers the BreakPlatform function
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // when colliding 
    {
        if (collision.collider.CompareTag("Player")) // if the object is tagged as "player"
        {
            playerOnPlatform = true; // start the timer
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // when exiting collision
    {
        if (collision.collider.CompareTag("Player")) // if the object is tagged as "player"
        {
            playerOnPlatform = false; // stop the timer
            timer = 0f; // reset to 0
        }
    }

    // function to make the platform disappear
    private void BreakPlatform()
    {
        spriteRenderer.enabled = false; // visually hides the platform
        platformCollider.enabled = false; // disables collision, dropping the player 
        playerOnPlatform = false; // reset player presence
        timer = 0f; // reset timer
        Invoke(nameof(ReappearPlatform), reappearDelay); // platform to reappear after delay
    }

    // function to make platform reappear
    private void ReappearPlatform()
    {
        spriteRenderer.enabled = true; // show the platform again
        platformCollider.enabled = true; // enables collision again, allowing the player to walk on it again
    }
}