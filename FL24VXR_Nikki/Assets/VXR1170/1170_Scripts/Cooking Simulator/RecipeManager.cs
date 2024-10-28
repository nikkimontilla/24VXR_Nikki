using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour //This class manages the game state, calls ingredient class, randamizes recipes and checking if ingredients selected match recipe.
{
    //Use lists to store ingredients that render at the start of game play + call ingredient class
    public List<Ingredient> ingredients = new List<Ingredient>();

    //Use lists to store recipes that randomize + call recipes class
    public List<Recipe> recipes = new List<Recipe>();

    //Use lists to track ingredients used by player
    public List<int> usedIngedients = new List<int>();



    public List<int> ingredientIDs = new List<int>() { 0, 1, 2, 3, 4 };

    public List<int> RandomIngredientList()
    {
        List<int> availableIDs = new List<int>(ingredientIDs);

        List<int> selectedIDs = new List<int>();

        for (int i = 0; i < 4 && availableIDs.Count > 0; i++)
        {

        }

        return selectedIDs;
    }

    public Transform[] recipeSpawn;

    private bool gameStarted = false;

    public int chosenRecipeID;

    //track score
    public float earnings;

    //reference to panlogic
    [SerializeField]
    private PanLogic panLogic;

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

    //calc score
    public void SpawnIngredients()
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

    

/*private void SpawnRecipe()
{
    for (int i = 0; i < recipes.Count; i++)
    {
        GameObject tempObj = Instantiate(ingredients[i].prefab);

        tempObj.name = i.ToString();

        Vector3 tempV3 = tempObj.transform.position;
        tempObj.transform.position = new Vector3(tempV3.x, tempV3.y, tempV3.z);


    }
}*/


public void ChooseRecipe()
    {
        //call clear console func
        clearConsole();

        //reset pan to reset game
        if (gameStarted)
        {
            ResetPan();
        }
        chosenRecipeID = Random.Range(0, recipes.Count - 1);

        //loop ingredients list to pick recipe
        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++)
        {

        }

    }

    

    public void clearConsole()
    {
        ResetPan();
        usedIngedients.Clear();
    }

    private void ResetPan()
    {

    }

    //public bool IsMatch(int recipeID, List<int> selectedIngredients)
    // {

    // }
    // Update is called once per frame
    void Update()
    {

    }
}
