using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoInDopplerEffect : MonoBehaviour
{
    public GameObject quizButtonCanvas;
    public GameObject dopplerEffectCanvas;
    public GameObject muteButtonCanvas;

    public GameObject charEcho;
    public AudioSource ambulanceSound;

    public AudioSource dopplerEffectIntroNarrative;

    public Transform targetLocation;

    void Start()
    {
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


        dopplerEffectCanvas.SetActive(true);
        quizButtonCanvas.SetActive(true);
        muteButtonCanvas.SetActive(true);
        ambulanceSound.mute = false;
    }
}
