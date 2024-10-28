using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

//This class controls player interaction
public class ItemClick : MonoBehaviour
{
    public int maxIngredients = 3;

    private static int currentIngredientCount = 0;
    private static List<GameObject> usedIngredients = new List<GameObject>();
    private bool isSelected = false;

    private void OnMouseDown()
    {
        if (!isSelected)
        {
            TrySelectIngredient();
            Debug.Log("yes");
        }
        
    }

    private void TrySelectIngredient()
    {
        // Check if we can add more ingredients
        if (currentIngredientCount >= maxIngredients)
        {
            Debug.Log($"Cannot add more ingredients! Maximum of {maxIngredients} reached.");
            return;
        }

        // Mark as selected and update tracking
        isSelected = true;
        currentIngredientCount++;
        usedIngredients.Add(gameObject);

    }
}
    
//clickCount func tracks the number of ingredients selected onto the pan; control the limit to 3

//OnMouseDown

// Start is called before the first frame update
/*void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}*/
