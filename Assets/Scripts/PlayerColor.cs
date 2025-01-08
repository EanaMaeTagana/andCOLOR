using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer; // player sprite renderer
    private int colorIndex = 0; // current color index
    public AudioClip colorSwapSound; // for the color change sound
    private AudioSource audioSource; // to play the sound

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); // get renderer
        audioSource = GetComponent<AudioSource>(); // get audio component
        UpdateColor(); // set initial color
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // check if c is pressed
        {
            SwitchColor(); // calls the function to switch color
        }
    }

    void SwitchColor()
    {
        colorIndex = (colorIndex + 1) % 4; // cycle through indices 1, 2, 3, and 4
        UpdateColor(); // calls the function to update the color 

        // Play the color change sound
        if (audioSource != null && colorSwapSound != null)
        {
            audioSource.PlayOneShot(colorSwapSound); // play the color change sound
        }
    }

    void UpdateColor()
    {
        switch (colorIndex)
        {
            case 0:
                playerSpriteRenderer.color = Color.white; // change to white
                break;
            case 1:
                playerSpriteRenderer.color = Color.red; // change to red
                break;
            case 2:
                playerSpriteRenderer.color = Color.green; // change to green
                break;
            case 3:
                playerSpriteRenderer.color = Color.blue; // change to blue
                break;
        }
    }

    public Color GetPlayerColor() 
    {
        return playerSpriteRenderer.color; // retrieves the current color
    }
}