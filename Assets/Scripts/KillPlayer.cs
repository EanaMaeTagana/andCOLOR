using UnityEngine;
using TMPro; 

public class KillPlayer : MonoBehaviour
{
    public TextMeshProUGUI deathText; // TextMeshProUGUI for displaying the death message
    public AudioClip deathSound; // AudioClip for the death sound
    private AudioSource audioSource; // AudioSource to play the death sound

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on the GameObject

        if (deathText != null)
        {
            deathText.gameObject.SetActive(false); // hide the death text initially
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // function is triggered when an object collides with the trigger collider
    {
        if (collision.CompareTag("Player")) // checks if collision was with the player
        {
            ResetCharacter(collision.gameObject); // calls the ResetCharacter function
        }
    }

    private void ResetCharacter(GameObject player)
    {
        // makes sure deathText is not empty
        if (deathText != null)
        {
            deathText.gameObject.SetActive(true); // show the death text
            deathText.text = "YOU DIED! :("; // set the message
        }

        // Play the death sound
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound); // play the death sound
        }

        // reload the scene after a delay
        Invoke("ReloadScene", 2f); // wait for 2 seconds before reloading
    }

    private void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        ); // reloads the current scene
    }
}