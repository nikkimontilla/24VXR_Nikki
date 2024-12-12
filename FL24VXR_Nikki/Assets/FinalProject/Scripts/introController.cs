using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public Image[] logos; // Drag logos here in inspector
    public float timeBetweenLogos = 1f;
    public float fadeTime = 0.5f;

    public AudioSource logoTune;

    void Start()
    {
        // Initially hide all logos
        foreach (Image logo in logos)
        {
            logo.gameObject.SetActive(false);
        }

        // Start the sequential reveal
        StartCoroutine(RevealLogosSequentially());
        logoTune.Play();
    }

    IEnumerator RevealLogosSequentially()
    {
        for (int i = 0; i < logos.Length; i++)
        {
            Image currentLogo = logos[i];

            yield return new WaitForSeconds(timeBetweenLogos);

            // Fade in current logo
            yield return StartCoroutine(FadeLogo(currentLogo, true));
            

            // Wait before next transition
            yield return new WaitForSeconds(timeBetweenLogos);

            // If not the last logo, fade out current logo
            if (i < logos.Length - 1)
            {
                yield return StartCoroutine(FadeLogo(currentLogo, false));
            }
        }

        // Transition to Home scene after showing all logos
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Home");
    }

    IEnumerator FadeLogo(Image logo, bool fadeIn)
    {
        CanvasGroup canvasGroup = logo.gameObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = logo.gameObject.AddComponent<CanvasGroup>();

        float startAlpha = fadeIn ? 0f : 1f;
        float targetAlpha = fadeIn ? 1f : 0f;

        // Activate logo for fade in, keep active for fade out
        if (fadeIn)
            logo.gameObject.SetActive(true);

        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;

        // Deactivate logo after fading out
        if (!fadeIn)
            logo.gameObject.SetActive(false);
    }
}
