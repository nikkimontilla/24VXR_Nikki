using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    //Create constructors by giving recipes a name, id, minCookTime, maxCookTime and a lists of ingredientIDs, recipe completion points
    //Call this Recipes class in the RecipeManager to create randomized recipes

    public string recipeName;
    public int recipeID;
    public int minCookTime;
    public int maxCookTime;
    public List<int> ingredientIDs = new List<int>() { 0, 1, 2, 3, 4 };
    public int recipeCompletionPoints;

    public Recipe(string _recipeName, int _recipeID, int _minCookTime, int _maxCookTime, List<int> _ingredientIDs, int _recipeCompletionPoints)
    {
        recipeName = _recipeName;
        recipeID = _recipeID;   
        minCookTime = _minCookTime;
        maxCookTime = _maxCookTime;
        ingredientIDs = _ingredientIDs;
        recipeCompletionPoints = _recipeCompletionPoints;
    }

    void Start()
    {
       
    }
}