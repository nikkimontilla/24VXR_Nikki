using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoInMainMenu : MonoBehaviour
{
    public AudioClip audioClip; // Drag your audio clip here in the inspector
    private AudioSource audioSource;

    // Static variable to track if the audio has been played across scene reloads
    private static bool hasBeenPlayed = false;

    void Awake()
    {
        // Ensure we only have one AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the audio clip if not already set in the inspector
        if (audioSource.clip == null && audioClip != null)
        {
            audioSource.clip = audioClip;
        }

        // Play the audio only if it hasn't been played before
        if (!hasBeenPlayed)
        {
            audioSource.Play();
            hasBeenPlayed = true;
        }
    }

    // Optional: Reset method if you want to allow replay in a new game session
    public void ResetAudioPlay()
    {
        hasBeenPlayed = false;
    }
}
