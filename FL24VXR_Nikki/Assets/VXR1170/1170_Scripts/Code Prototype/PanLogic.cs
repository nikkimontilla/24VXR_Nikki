using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanLogic : MonoBehaviour //This class manages the timer of game play and checks how fast the player selects ingredients and this affects the score
{
    // References and UI elements
    [SerializeField]
    public RecipeManager recipeManager;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI timerText;

    //variables to determine cook time
    private int min;
    private int max;
    private float timer = 0f;

    [SerializeField]
    private float timerValue = 30f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginTimer());
    }
 
    private void OnMouseDown()
    {
        StopAllCoroutines();

        if (timer < min && timer != 0)
        {
            Debug.Log("Undercooked!");
            scoreText.text = "Score: $0";
            float earnings = recipeManager.calcEarnings(false);
        }
        else if (timer > max && timer != 0)
        {
            Debug.Log("Overcooked!");
            scoreText.text = "Score: $0";
            float earnings = recipeManager.calcEarnings(true);
        }
        else if (timer != 0)
        {
            Debug.Log("Perfect");
        }
        timer = 0;
        recipeManager.ChooseRecipe();
    }

    public void startCountDown(int _min, int _max)
    {
        min = _min;
        max = _max;

        StartCoroutine(BeginTimer());
    }

    IEnumerator BeginTimer()
    {
        while (timerValue >= 0)
        {
            timerValue -= Time.deltaTime;
            timerText.text = "Time:" + (int)timerValue;
            yield return null;
        }
        timerText.text = "Time: 0";
    }
}
