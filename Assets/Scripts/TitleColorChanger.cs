using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public TextMeshProUGUI text;  // Drag your TextMeshPro object here
    private float changeInterval = 1f;  // Interval time in seconds
    private float timer = 0f;  // Timer to track when to change the color
    private int currentColorIndex = 0;

    // Define the colors to cycle through: Green, Red, Blue, and White
    private Color[] colors = { Color.green, Color.red, Color.blue, Color.white };

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // If the timer exceeds the interval, change the color
        if (timer >= changeInterval)
        {
            // Change the color to the next one in the array
            text.color = colors[currentColorIndex];

            // Reset the timer
            timer = 0f;

            // Cycle to the next color (wrap back to 0 when reaching the end)
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
        }
    }
}
