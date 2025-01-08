using UnityEngine;

public class RedTransparentPlatform : MonoBehaviour
{
    public Color platformColor = Color.red; // platform color (set to red)
    private BoxCollider2D platformCollider; // platform collider

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // get platform's renderer
        platformCollider = GetComponent<BoxCollider2D>(); // get platform's collider

        if (spriteRenderer != null) // if renderer is not empty
        {
            spriteRenderer.color = platformColor; // set the platform color to red
        }
    }

    void Update()
    {
        if (platformCollider != null) // if collider is not empty
        {
            Color playerColor = GetPlayerColor(); // get player's color

            if (playerColor != platformColor) // if player color not matching platform color
            {
                platformCollider.enabled = false; // disable collider, causing the platform to be unwalkable 
            }
            else
            {
                platformCollider.enabled = true; // enable collider, player can walk
            }
        }
    }

    Color GetPlayerColor()
    {
        PlayerColor playerColorScript = FindObjectOfType<PlayerColor>(); // finds player color script
        return playerColorScript.GetPlayerColor(); // gets the player's current color
    }
}