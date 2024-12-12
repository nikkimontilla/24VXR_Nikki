using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizDopplerEffect : MonoBehaviour
{
    // Reference to ALL quiz related canvases
    public GameObject dopplerEffectCanvas;
    public GameObject muteButtonCanvas;
    public GameObject quizDopplerEffectCanvas;
    public GameObject correctAnswerCanvas;
    public GameObject wrongAnswerCanvas;

    public void Start()
    {
        // Ensure canvases is hidden at the start
        quizDopplerEffectCanvas.SetActive(false);   
        correctAnswerCanvas.SetActive(false);
        wrongAnswerCanvas.SetActive(false);
    }

    // Method to be called when the quiz button is clicked
    public void questionCanvasAppear()
    {
        // Check if both canvases are assigned
        if (quizDopplerEffectCanvas != null && dopplerEffectCanvas != null)
        {
            // Hide everything except the question canvas
            dopplerEffectCanvas.SetActive(false);
            muteButtonCanvas.SetActive(false);
            correctAnswerCanvas.SetActive(false);
            wrongAnswerCanvas.SetActive(false);

            // Show the quiz canvas
            quizDopplerEffectCanvas.SetActive(true);
        }
    }

    // Method to be called when correct button is clicked
    public void correctCanvasAppear()
    {
        if (quizDopplerEffectCanvas != null && correctAnswerCanvas != null && wrongAnswerCanvas != null)
        {
            correctAnswerCanvas.SetActive(true);

            quizDopplerEffectCanvas.SetActive(false);
        }
    }

    //Method to be called when wrong button is clicked
    public void wrongCanvasAppear()
    {
        if (quizDopplerEffectCanvas != null && correctAnswerCanvas != null && wrongAnswerCanvas != null)
        {
            wrongAnswerCanvas.SetActive(true);

            quizDopplerEffectCanvas.SetActive(false);
        }
    }

    // Method to return to original scene
    public void coolAppear()
    {
        dopplerEffectCanvas.SetActive(true);
        muteButtonCanvas.SetActive(true);

        quizDopplerEffectCanvas.SetActive(false);
        correctAnswerCanvas.SetActive(false);
        wrongAnswerCanvas.SetActive(false);
    }

    //Method to make question reappear
    public void tryAgainAppear()
    {
        questionCanvasAppear();
    }

    public void exitButton()
    {
        coolAppear();
    }

}
