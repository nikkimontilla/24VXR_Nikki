using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoInDopplerEffect : MonoBehaviour
{
    //Reference to Canvas containting Game UI for the scene
    public GameObject quizButtonCanvas;
    public GameObject dopplerEffectCanvas;
    public GameObject muteButtonCanvas;

    //Reference to Echo
    public GameObject charEcho;

    //Reference to ambulance audio
    public AudioSource ambulanceSound;

    //Reference to introduction audio
    public AudioSource dopplerEffectIntroNarrative;

    // Reference to new location of Echo
    public Transform targetLocation;

    void Start()
    {
        // Disable all UI except Echo and introduction audio
        dopplerEffectCanvas.SetActive(false);
        quizButtonCanvas.SetActive(false);
        muteButtonCanvas.SetActive(false);

        charEcho.SetActive(true);

        ambulanceSound.mute = true;

        echoDopplerEffectIntro();
    }

    public void echoDopplerEffectIntro()
    {
        // Play intro narrative for this scene
        if (dopplerEffectIntroNarrative != null)
        {
            StartCoroutine(PlayAudioThenMove());
        }
    }

    private IEnumerator PlayAudioThenMove()
    {
        // Play the audio
        dopplerEffectIntroNarrative.Play();

        // Wait until the audio finishes
        yield return new WaitForSeconds(dopplerEffectIntroNarrative.clip.length);

        // Now start moving the character
        StartCoroutine(moveCharEcho());
    }

    // Method to move Echo
    public IEnumerator moveCharEcho()
    {
        Vector3 startPosition = charEcho.transform.position;
        Vector3 endPosition = targetLocation.position;
        float moveTime = 2f; // Movement duration
        float elapsedTime = 0;

        while (elapsedTime < moveTime)
        {
            charEcho.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveTime);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        charEcho.transform.position = endPosition;

        // Enable game UI needed after Echo introduction
        dopplerEffectCanvas.SetActive(true);
        quizButtonCanvas.SetActive(true);
        muteButtonCanvas.SetActive(true);
        ambulanceSound.mute = false;
    }
}
