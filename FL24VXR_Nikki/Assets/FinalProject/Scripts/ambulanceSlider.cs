using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ambulanceSlider : MonoBehaviour
{ 
    // Reference to the slider
    public Slider positionSlider;

    // Reference to the ambulance
    public Transform ambulance;

    // Reference to the AudioSource for Doppler and Volume control
    public AudioSource audioSourceToControl;

    // Minimum and maximum X positions for the ambulance
    public float minXPosition = -5f;
    public float maxXPosition = 5f;

    // Doppler effect range settings
    public float minDopplerLevel = 0f;
    public float maxDopplerLevel = 3f;

    // Volume range settings
    public float minVolume = 0.5f;
    public float maxVolume = 1f;

    void Start()
    { 

        // Set up the slider's range between 0 and 1
        positionSlider.minValue = 0f;
        positionSlider.maxValue = 1f;

        // Set default to center
        positionSlider.value = 0.5f;

        // Add a listener to update object position and audio when slider changes
        positionSlider.onValueChanged.AddListener(UpdateObjectPositionAndAudio);
    }

    void UpdateObjectPositionAndAudio(float sliderValue)
    {
        // Calculate new X position based on slider value
        float newXPosition = Mathf.Lerp(minXPosition, maxXPosition, sliderValue);

        // Create new position vector
        Vector3 newPosition = ambulance.position;
        newPosition.x = newXPosition;

        // Apply new position
        ambulance.position = newPosition;

        // Modify audio
        if (audioSourceToControl != null)
        {
            // Adjusted volume calculation
            float volumeMultiplier;
            if (sliderValue >= 0.5f)
            {
                // Right side: map from 0.5-1.0 to minVolume-maxVolume
                volumeMultiplier = Mathf.Lerp(minVolume, maxVolume, (sliderValue - 0.5f) * 2f);
            }
            else
            {
                // Left side: map from 0-0.5 to minVolume-maxVolume
                volumeMultiplier = Mathf.Lerp(minVolume, maxVolume, (0.5f - sliderValue) * 2f);
            }

            audioSourceToControl.volume = volumeMultiplier;

            // Symmetrical Doppler level
            float dopplerMultiplier;
            if (sliderValue >= 0.5f)
            {
                // Right side: interpolate from 0 to max Doppler
                dopplerMultiplier = Mathf.Lerp(0f, maxDopplerLevel, (sliderValue - 0.5f) * 2f);
            }
            else
            {
                // Left side: interpolate from 0 to max Doppler
                dopplerMultiplier = Mathf.Lerp(0f, maxDopplerLevel, (0.5f - sliderValue) * 2f);
            }

            audioSourceToControl.dopplerLevel = dopplerMultiplier;
        }
    }
}
