using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brainAnnotations : MonoBehaviour
{
    // Reference to all canvas containing definitions
    public GameObject sensoryCortexCanvas;
    public GameObject motorCortexCanvas;
    public GameObject prefrontalCortexCanvas;
    public GameObject visualCortexCanvas;
    public GameObject auditoryCortexCanvas;

    // Currently playing audio source
    private AudioSource currentlyPlayingAudio = null;

    public void Start()
    {
        sensoryCortexCanvas.SetActive(false);
        motorCortexCanvas.SetActive(false);
        prefrontalCortexCanvas.SetActive(false);
        visualCortexCanvas.SetActive(false);
        auditoryCortexCanvas.SetActive(false);

    }

    // Method to be called when Sensory C
    public void sensoryCortexCanvasAppear()
    {
        sensoryCortexCanvas.SetActive(true);

        motorCortexCanvas.SetActive(false);
        prefrontalCortexCanvas.SetActive(false);
        visualCortexCanvas.SetActive(false);
        auditoryCortexCanvas.SetActive(false);
    }

    public void motorCortexCanvasAppear()
    {
        motorCortexCanvas.SetActive(true);

        sensoryCortexCanvas.SetActive(false);
        prefrontalCortexCanvas.SetActive(false);
        visualCortexCanvas.SetActive(false);
        auditoryCortexCanvas.SetActive(false);
    }

    public void prefrontCortexCanvasAppear()
    {
        prefrontalCortexCanvas.SetActive(true);

        motorCortexCanvas.SetActive(false);
        sensoryCortexCanvas.SetActive(false);
        visualCortexCanvas.SetActive(false);
        auditoryCortexCanvas.SetActive(false);
    }

    public void visualCortexCanvasAppear()
    {
        visualCortexCanvas.SetActive(true);

        prefrontalCortexCanvas.SetActive(false);
        motorCortexCanvas.SetActive(false);
        sensoryCortexCanvas.SetActive(false);
        auditoryCortexCanvas.SetActive(false);
    }

    public void auditoryCortexCanvasAppear()
    {
        auditoryCortexCanvas.SetActive(true);

        visualCortexCanvas.SetActive(false);
        prefrontalCortexCanvas.SetActive(false);
        motorCortexCanvas.SetActive(false);
        sensoryCortexCanvas.SetActive(false);
    }

    public void PlayButtonAudio(AudioSource audioSourceToPlay)
    {
        // If there's an audio currently playing, stop it
        if (currentlyPlayingAudio != null && currentlyPlayingAudio.isPlaying)
        {
            currentlyPlayingAudio.Stop();
        }

        // Play the new audio
        audioSourceToPlay.Play();

        // Update the currently playing audio reference
        currentlyPlayingAudio = audioSourceToPlay;
    }

    // Optional: Method to stop all audio
    public void StopAllAudio()
    {
        if (currentlyPlayingAudio != null)
        {
            currentlyPlayingAudio.Stop();
            currentlyPlayingAudio = null;
        }
    }
}
