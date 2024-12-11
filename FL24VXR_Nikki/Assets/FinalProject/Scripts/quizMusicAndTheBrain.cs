using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizMusicAndTheBrain : MonoBehaviour
{
    // Reference to ALL quiz related canvases
    public GameObject sensoryCortexCanvas;
    public GameObject motorCortexCanvas;
    public GameObject prefrontalCortexCanvas;
    public GameObject visualCortexCanvas;
    public GameObject auditoryCortexCanvas;

    public GameObject quizMusicAndTheBrainCanvas;
    public GameObject correctAnswerCanvas;
    public GameObject wrongAnswerCanvas;

    public GameObject buttonCanvas;

    public void Start()
    {
        // Ensure quizSoundLayersCanvas is hidden at the start
        quizMusicAndTheBrainCanvas.SetActive(false);
        correctAnswerCanvas.SetActive(false);
        wrongAnswerCanvas.SetActive(false);
        buttonCanvas.SetActive(true);
    }

    // Method to be called when the quiz button is clicked
    public void questionCanvasAppear()
    {
        // Check if both canvases are assigned
        if (quizMusicAndTheBrainCanvas != null)
        {
            // Hide everything except the question canvas
            correctAnswerCanvas.SetActive(false);
            wrongAnswerCanvas.SetActive(false);

            sensoryCortexCanvas.SetActive(false);
            motorCortexCanvas.SetActive(false);
            prefrontalCortexCanvas.SetActive(false);
            visualCortexCanvas.SetActive(false);
            auditoryCortexCanvas.SetActive(false);
            buttonCanvas.SetActive(false);

            // Show the quizSoundLayersCanvas
            quizMusicAndTheBrainCanvas.SetActive(true);
        }
    }

    // Method to be called when correct button is clicked
    public void correctCanvasAppear()
    {
        if (quizMusicAndTheBrainCanvas != null && correctAnswerCanvas != null && wrongAnswerCanvas != null)
        {
            correctAnswerCanvas.SetActive(true);

            quizMusicAndTheBrainCanvas.SetActive(false);
        }
    }

    //Method to be called when wrong button is clicked
    public void wrongCanvasAppear()
    {
        if (quizMusicAndTheBrainCanvas != null && correctAnswerCanvas != null && wrongAnswerCanvas != null)
        {
            wrongAnswerCanvas.SetActive(true);

            quizMusicAndTheBrainCanvas.SetActive(false);
        }
    }

    // Method to return to original scene
    public void coolAppear()
    {
        buttonCanvas.SetActive(true);

        quizMusicAndTheBrainCanvas.SetActive(false);
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
