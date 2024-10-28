using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanLogic : MonoBehaviour //This class manages the timer of game play and checks how fast the player selects ingredients and this affects the score
{
    //reference to allow instantiation 
    [SerializeField]
    RecipeManager recipeManager;

    [SerializeField]
    private float timerValue = 30;

    [SerializeField]
    TextMeshProUGUI timerText;


    // Start is called before the first frame update
    void Start()
    {
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