using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoInSoundLayers : MonoBehaviour
{
    public GameObject quizButtonCanvas;
    public GameObject soundLayersCanvas;

    public GameObject charEcho;

    public AudioSource soundLayerIntroNarrative;

    public Transform targetLocation;

    void Start()
    {
        soundLayersCanvas.SetActive(false);
        quizButtonCanvas.SetActive(false);

        charEcho.SetActive(true);

        echoSoundLayerIntro();
    }

    public void echoSoundLayerIntro()
    {
        // Play intro narrative for this scene
        if (soundLayerIntroNarrative != null)
        {
            StartCoroutine(PlayAudioThenMove());
        }
    }

    private IEnumerator PlayAudioThenMove()
    {
        // Play the audio
        soundLayerIntroNarrative.Play();

        // Wait until the audio finishes
        yield return new WaitForSeconds(soundLayerIntroNarrative.clip.length);

        // Now start moving the character
        StartCoroutine(moveCharEcho());
    }

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
        

        soundLayersCanvas.SetActive(true);
        quizButtonCanvas.SetActive(true);
    }
}
