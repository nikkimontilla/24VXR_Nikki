using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mainMenuAnimation : MonoBehaviour
{
    public Button[] buttons; 
    public float timeBetweenButtons = 1f; // Time between button appearances
    public bool useAnimation = true;
    void Start()
    {
        // Initially hide all buttons
        foreach (Button btn in buttons)
        {
            btn.gameObject.SetActive(false);
        }
        // Start the sequential reveal
        StartCoroutine(RevealButtonsSequentially());
    }
    IEnumerator RevealButtonsSequentially()
    {
        foreach (Button btn in buttons)
        {
            // Simple Active/Inactive method
            if (!useAnimation)
            {
                btn.gameObject.SetActive(true);
            }
            // Fade-in method with animation
            else
            {
                CanvasGroup canvasGroup = btn.gameObject.GetComponent<CanvasGroup>();
                if (canvasGroup == null)
                    canvasGroup = btn.gameObject.AddComponent<CanvasGroup>();
                // Fade-in effect
                float fadeTime = 0.5f;
                float elapsedTime = 0f;
                btn.gameObject.SetActive(true);
                canvasGroup.alpha = 0f;
                while (elapsedTime < fadeTime)
                {
                    canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                canvasGroup.alpha = 1f;
            }
            // Wait before showing next button
            yield return new WaitForSeconds(timeBetweenButtons);
        }
    }
}
