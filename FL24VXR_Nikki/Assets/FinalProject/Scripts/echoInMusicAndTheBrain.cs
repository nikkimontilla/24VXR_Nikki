using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoInMusicAndTheBrain : MonoBehaviour
{
    public GameObject buttonCanvas;
    public GameObject quizButtonCanvas;

    public GameObject charEcho;
    public GameObject humanBrain;

    public AudioSource musicIntroNarrative;

    public Transform targetLocation;

    void Start()
    {
        buttonCanvas.SetActive(false);
        humanBrain.SetActive(false);
        quizButtonCanvas.SetActive(false);

        charEcho.SetActive(true);

        echoIntro();
    }

    public void echoIntro()
    {
        // Play intro narrative for this scene
        if (musicIntroNarrative != null)
        {
            StartCoroutine(PlayAudioThenMove());
        }
    }

    private IEnumerator PlayAudioThenMove()
    {
        // Play the audio
        musicIntroNarrative.Play();

        // Wait until the audio finishes
        yield return new WaitForSeconds(musicIntroNarrative.clip.length);

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

        buttonCanvas.SetActive(true);
        humanBrain.SetActive(true);
        quizButtonCanvas.SetActive(true);
    }

    void Update()
    {

    }
}
