using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class RecipeManager : MonoBehaviour //This class manages the game state, calls ingredient class, randamizes recipes and checking if ingredients selected match recipe.
{
    //Use lists to store ingredients that render at the start of game play + call ingredient class
    public List<Ingredient> ingredients = new List<Ingredient>();

    //Use lists to store recipes that randomize + call recipes class
    public List<Recipe> recipes = new List<Recipe>();

    //Use lists to track ingredients used by player
    public List<int> usedIngredients = new List<int>();

    //array of recipe spawn
    public Transform[] recipeSpawn;

    //variable for chosen recipe
    public int chosenRecipeID;

    //reference to panlogic
    [SerializeField]
    private PanLogic panLogic;

    //track score
    public float earnings;

    // Tracks whether the game/cooking session has started
    private bool gameStarted = false;

    public void chooseIngredient(int ingredientID) // Handles the selection of an ingredient by the player
    {
        usedIngredients.Add(ingredientID); // Add the selected ingredient to the list of ingredients used in the current recipe attempt

        if (usedIngredients.Count == recipes[chosenRecipeID].ingredientIDs.Count) // Check if player has selected all required ingredients for the chosen recipe
        {
            Debug.Log("Choosen recipe is the same as used recipe");
            bool ingredientListsMatch = usedIngredients.Equals(recipes[chosenRecipeID].ingredientIDs); // Compare if the selected ingredients match exactly with the recipe requirements

            if (ingredientListsMatch) // If all ingredients match correctly, start the cooking countdown timer
            {
                panLogic.startCountDown(0, 0);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Make ingredients options appear at start of game play by calling its list name
        //identify each ingredient (ingredientName, id, prefab, dollarValue)
        ingredients.Add(new Ingredient("Green Cube", 0, Resources.Load("Ingredients/GreenCube") as GameObject, 3));
        ingredients.Add(new Ingredient("Orange Cube", 1, Resources.Load("Ingredients/OrangeCube") as GameObject, 5));
        ingredients.Add(new Ingredient("Red Cube", 2, Resources.Load("Ingredients/RedCube") as GameObject, 7));
        ingredients.Add(new Ingredient("Purple Sphere", 3, Resources.Load("Ingredients/PurpleSphere") as GameObject, 9));
        ingredients.Add(new Ingredient("Yellow Sphere", 4, Resources.Load("Ingredients/YellowSphere") as GameObject, 11));

        //Create random recipes using RandomIngredientList func
        //identify each recipe (recipeName, id, minCookTime, maxCookTime, a lists of ingredientIDs, and recipe completion value)
        recipes.Add(new Recipe("Recipe 1", 0, 2, 6, RandomIngredientList(), 30));
        recipes.Add(new Recipe("Recipe 2", 1, 2, 7, RandomIngredientList(), 40));
        recipes.Add(new Recipe("Recipe 3", 2, 1, 5, RandomIngredientList(), 50));
        recipes.Add(new Recipe("Recipe 4", 3, 1, 4, RandomIngredientList(), 60));

        //call spawn ingredient func
        SpawnIngredients();

        //call choose recipe func
        ChooseRecipe();
    }

    public float calcEarnings(bool gain) /// Calculates the earnings from the current recipe, either with or without profit markup
    {
        float temp = 0; // Temporary variable to store running total

        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++) // Sum up the base score of all ingredients in the chosen recipe
        {
            temp += ingredients[recipes[chosenRecipeID].ingredientIDs[i]].dollarValue; // Add each ingredient's dollar value to the total

        }
        if (gain)
        {
            temp = temp + (temp / recipes[chosenRecipeID].markup);
            earnings += temp;
        }
        else // If gain is false, no increase in earnings
        {
            earnings = temp;
        }
        return temp;
    }

    public void ChooseRecipe()
    {
        // Reset pan if game is already in progress
        if (gameStarted)
        {
            ResetPan();
        }

        chosenRecipeID = Random.Range(0, recipes.Count);  // Randomly select a recipe

        // Find the recipe location objects
        Transform recipeLoc1 = GameObject.Find("RecipeLoc1").transform;
        Transform recipeLoc2 = GameObject.Find("RecipeLoc2").transform;
        Transform recipeLoc3 = GameObject.Find("RecipeLoc3").transform;

        // Store locations in array for easy access
        Transform[] recipeLocations = { recipeLoc1, recipeLoc2, recipeLoc3 };

        // Loop through and instantiate each required ingredient
        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++)
        {
            if (i < recipeLocations.Length && recipeLocations[i] != null)
            {
                // Create the ingredient prefab instance
                GameObject tmp = Instantiate(ingredients[recipes[chosenRecipeID].ingredientIDs[i]].prefab);

                // Set parent to the corresponding RecipeLoc
                tmp.transform.SetParent(recipeLocations[i], false);
                tmp.transform.parent = recipeSpawn[i];

                // Reset position and scale
                tmp.transform.position = Vector3.zero;
                tmp.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        gameStarted = true;
    }

    private void ResetPan() //clear pan of selected ingredients
    {
        // Clean up pan items if they exist
        GameObject panItem1 = GameObject.Find("Pan Item 1");
        GameObject panItem2 = GameObject.Find("Pan Item 2");
        GameObject panItem3 = GameObject.Find("Pan Item 3");

        if (panItem1 != null) Destroy(panItem1);
        if (panItem2 != null) Destroy(panItem2);
        if (panItem3 != null) Destroy(panItem3);

        // Safely destroy children of recipe spawn points
        for (int i = 0; i < recipeSpawn.Length; i++)
        {
            // Check if the spawn point has any children before trying to destroy them
            if (recipeSpawn[i] != null && recipeSpawn[i].childCount > 0)
            {
                Destroy(recipeSpawn[i].GetChild(0).gameObject);
            }
        }

        usedIngredients.Clear();
    }

    private List<int> RandomIngredientList() // Generates a random list of ingredient IDs for recipe creation
    {
        List<int> tempList = new List<int>();   // Create a temporary list to store the random ingredient IDs

        for (int i = 0; i < Recipe.maxIngredients; i++) // Generate random ingredient IDs up to the maximum allowed ingredients per recipe
        {
            tempList.Add(Random.Range(0, ingredients.Count - 1)); // Add a random ingredient ID from the available ingredients list
        }

        return tempList;
    }

    private void SpawnIngredients()
    {
        //loop ingredient list
        for (int i = 0; i < ingredients.Count; i++)
        {
            //instantiate ingredients from list
            GameObject tempObj = Instantiate(ingredients[i].prefab);
            //rename to associate with ingredient ID
            tempObj.name = i.ToString();
            // offset ingredients
            Vector3 tempV3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempV3.x, tempV3.y, tempV3.z);

        }
    }

    public bool isMatch(int recipeID, List<int> selectedIngredients) //Checks if the selected ingredients match the recipe's required ingredients
    {
        if (recipeID >= 0 && recipeID < recipes.Count)
        {
            Recipe targetRecipe = recipes[recipeID];

            // First check if the number of ingredients matches
            if (targetRecipe.ingredientIDs.Count != selectedIngredients.Count)
            {
                calcEarnings(false);
                return false;
            }

            // Compare each ingredient
            for (int i = 0; i < targetRecipe.ingredientIDs.Count; i++)
            {
                if (targetRecipe.ingredientIDs[i] != selectedIngredients[i])
                {
                    calcEarnings(false);
                    return false;
                }
            }
            return true;
        }

        calcEarnings(false);
        return false;
    }
}
