using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    //Create constructors by giving each ingredient a name, id, prefab and value to track score.
    //Call this Ingredient class in RecipeManager to instantiate ingredient options when you start game
    public string ingredientName;
    public int id;
    public GameObject prefab;
    public int dollarValue;

    public Ingredient(string _ingredientName, int _id, GameObject _prefab, int _dollarValue)
    {
        ingredientName = _ingredientName;
        id = _id;
        prefab = _prefab;
        dollarValue = _dollarValue;
    }
}
