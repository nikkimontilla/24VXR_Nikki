using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// In the series of quiz panels, when the buttons are clicked the audio does not get a chance to play as the panels switches.
public class vrButton : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject targetPanel;

    // If using XR Interaction Toolkit's button/interactable
    public void OnVRButtonClicked()
    {
        audioSource.Play();

        // Slight delay to ensure sound plays
        Invoke("ShowPanel", 1f);
    }

    void ShowPanel()
    {
        targetPanel.SetActive(true);
    }
}
