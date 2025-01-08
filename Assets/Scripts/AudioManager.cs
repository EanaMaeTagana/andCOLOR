using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;  // audio clip
    private AudioSource audioSource;    // audiosource component 
    public float volume = 0.4f; // audio volume

    void Start()
    {
        DontDestroyOnLoad(gameObject); // keeps the audio throughout the game

        // gets the audiosource component
        audioSource = GetComponent<AudioSource>();
        
        if (backgroundMusic != null) // if not empty
        {
            audioSource.clip = backgroundMusic; // assign the clip
            audioSource.loop = true; // enable looping
            audioSource.volume = volume; // set the volume
            audioSource.Play(); // start playing the music
        }
    }

    void OnLevelWasLoaded(int level)
    {
        // makes sure that the music plays through all scenes
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}