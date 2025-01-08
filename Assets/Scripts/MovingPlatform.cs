using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;  // moving platform
    public Transform startPoint;  // start position
    public Transform endPoint;  // end position
    public float speed = 1.5f; // speed of movement
    public Color platformColor = Color.blue;  // platform color set to blue

    private int direction = 1; // direction of movement

    private void Update()
    {
        Vector2 target = CurrentMovementTarget(); // gets the current target
        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime); // moves the platform

        float distance = (target - (Vector2)platform.position).magnitude; // check distance to target

        // reverse direction if close enough
        if (distance <= 0.1f)
        {
            direction *= -1;
        }

        HandleColorMatching(); // calls color matching function
    }

    private Vector2 CurrentMovementTarget()
    {
        return direction == 1 ? startPoint.position : endPoint.position; // determines the direction and sets the target
    }

    private void HandleColorMatching()
    {
        // get the player's current color from the PlayerColor script
        PlayerColor playerColorScript = FindObjectOfType<PlayerColor>();

        if (playerColorScript != null)
        {
            Color playerColor = playerColorScript.GetPlayerColor(); // gets player color

            if (playerColor == platformColor) // if player color matches platform color (blue) 
            {
                platform.GetComponent<BoxCollider2D>().enabled = true;  // enables the platform's collider if matching
            }
            else
            {
                platform.GetComponent<BoxCollider2D>().enabled = false; // disable the platform's collider if not matching
            }
        }
    }

    private void OnDrawGizmos()
    {
        // visualisation purposes, draws the start and end points of the moving platforms
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }
}
