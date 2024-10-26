using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    //Create constructors by giving recipes a name, id, minCookTime, maxCookTime and a lists of ingredientIDs, recipe completion points
    //Call this Recipes class in the RecipeManager to create randomized recipes

    public string recipeName;
    public int id;
    public int minCookTime;
    public int maxCookTime;
    public List<int> RandomIngredientList;
    public int recipeCompletionPoints;

    public Recipe(string _recipeName, int _id, int _minCookTime, int _maxCookTime, List<int> _RandomIngredientList, int _recipeCompletionPoints)
    {
        recipeName = _recipeName;
        id = _id;   
        minCookTime = _minCookTime;
        maxCookTime = _maxCookTime;
        RandomIngredientList = _RandomIngredientList;
        recipeCompletionPoints = _recipeCompletionPoints;
    }

    void Start()
    {
       
    }
}