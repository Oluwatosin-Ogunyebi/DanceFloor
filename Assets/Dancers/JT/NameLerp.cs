using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameLerp : MonoBehaviour
{
    public Color startColor; // Starting color
    public Color targetColor = Color.black; // Target color
    public float lerpDuration = 2.0f; // Duration of the color change in seconds

    private Material material; // Reference to the material
    private float lerpStartTime; // Time when lerping started

    private void Start()
    {
        // Get the material from the Renderer component
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            startColor = material.color;
        }
        else
        {
            Debug.LogError("Renderer component not found on the GameObject.");
        }

        // Initialize the lerp start time
        lerpStartTime = Time.time;
    }

    private void Update()
     {
        // Calculate the lerp factor using PingPong to smoothly transition up and down
        float lerpFactor = Mathf.PingPong(Time.time / lerpDuration, 2.0f);

        // Perform the color lerp
        material.color = Color.Lerp(startColor, targetColor, lerpFactor);
    }
}
