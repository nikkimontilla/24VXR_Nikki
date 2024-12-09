using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizSoundLayers : MonoBehaviour
{
    // Reference to ALL quiz related canvases
    public GameObject soundLayersCanvas;
    public GameObject quizSoundLayersCanvas;
    public GameObject correctAnswerCanvas;
    public GameObject wrongAnswerCanvas;

    public void Start()
    {
        // Ensure quizSoundLayersCanvas is hidden at the start
        quizSoundLayersCanvas.SetActive(false);
        correctAnswerCanvas.SetActive(false);
        wrongAnswerCanvas.SetActive(false);
    }

    // Method to be called when the quiz button is clicked
    public void questionCanvasAppear()
    {
        // Check if both canvases are assigned
        if (quizSoundLayersCanvas != null && soundLayersCanvas != null)
        {
            // Hide everything except the question canvas
            soundLayersCanvas.SetActive(false);
            correctAnswerCanvas.SetActive(false);
            wrongAnswerCanvas.SetActive(false);

            // Show the quizSoundLayersCanvas
            quizSoundLayersCanvas.SetActive(true);
        }
    }

    // Method to be called when correct button is clicked
   public void correctCanvasAppear()
    {
        if (quizSoundLayersCanvas != null && correctAnswerCanvas != null && wrongAnswerCanvas !=null)
        {
            correctAnswerCanvas.SetActive(true);

            quizSoundLayersCanvas.SetActive(false);
        }
    }

    //Method to be called when wrong button is clicked
    public void wrongCanvasAppear()
    {
        if (quizSoundLayersCanvas != null && correctAnswerCanvas != null && wrongAnswerCanvas != null)
        {
            wrongAnswerCanvas.SetActive(true);

            quizSoundLayersCanvas.SetActive(false);
        }
    }

    // Method to return to original scene
    public void coolAppear()
    {
        soundLayersCanvas.SetActive(true);

        quizSoundLayersCanvas.SetActive(false);
        correctAnswerCanvas.SetActive(false);
        wrongAnswerCanvas.SetActive(false);
    }

    //Method to make question reappear
    public void tryAgainAppear()
    {
        questionCanvasAppear();
    }
   
}
