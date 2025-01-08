using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextScene; // name of the next scene to be loaded
    public AudioClip portalSound; // for the portal sound
    private AudioSource audioSource; // to play the portal sound

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // get the AudioSource component
    }

    private void OnTriggerEnter2D(Collider2D collision) // detects collision
    {
        // checks if the player has entered the 'portal'
        if (collision.CompareTag("Player"))
        {
            // if audio source and audio clip is not empty 
            if (audioSource != null && portalSound != null)
            {
                audioSource.PlayOneShot(portalSound); // play the portal sound
            }

            // load the next scene after 1 second
            Invoke("LoadNextLevel", 1f);
        }
    }

    void LoadNextLevel()
    {
        // makes sure that there is an existing scene
        if (!string.IsNullOrEmpty(nextScene))
        {
            // loads the next level
            SceneManager.LoadScene(nextScene); 
        }
    }
}
