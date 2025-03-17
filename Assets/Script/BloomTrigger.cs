using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BloomTrigger : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; // Reference to the Post Process Volume
    private Bloom bloomLayer; // Reference to the Bloom effect

    private void Start()
    {
        // Get the Bloom effect from the Post Process Volume
        postProcessVolume.profile.TryGetSettings(out bloomLayer);
        if (bloomLayer != null)
        {
            bloomLayer.intensity.value = 0; // Set initial intensity to 0
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object entering is the player
        {
            if (bloomLayer != null)
            {
                bloomLayer.intensity.value = 1; // Activate bloom effect
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object exiting is the player
        {
            if (bloomLayer != null)
            {
                bloomLayer.intensity.value = 0; // Deactivate bloom effect
            }
        }
    }
}
