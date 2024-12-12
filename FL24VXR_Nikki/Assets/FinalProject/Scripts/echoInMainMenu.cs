using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoInMainMenu : MonoBehaviour
{
    public AudioClip audioClip; 
    private AudioSource audioSource;

    // Static variable to track if the audio has been played across scene reloads
    private static bool hasBeenPlayed = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the audio clip
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

    
}
