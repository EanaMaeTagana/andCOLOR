using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    public Color platformColor = Color.green; // platform color (set to green)
    public float bounceForce = 10f; // bounce force
    public AudioClip bounceSound; // for the bounce sound

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource; // to play the bounce sound

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // gets the sprite renderer component
        audioSource = GetComponent<AudioSource>(); // gets the audio component

        if (spriteRenderer != null) // if not empty
        {
            spriteRenderer.color = platformColor; // set the platform color
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // detects collision
    {
        PlayerColor playerColorScript = collision.collider.GetComponent<PlayerColor>(); // checks player color through the PlayerColor script

        if (playerColorScript != null && playerColorScript.GetPlayerColor() == platformColor) // check if matching platform color
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>(); // gets player's rigidbody
            if (rb != null) // if not empty
            {
                Vector2 bounce = new Vector2(rb.velocity.x, bounceForce); // sets the bounce velocity
                rb.velocity = bounce; // applies the bounce force

                // Play the bounce sound
                if (audioSource != null && bounceSound != null)
                {
                    audioSource.PlayOneShot(bounceSound); // play the bounce sound
                }
            }
        }
    }
}