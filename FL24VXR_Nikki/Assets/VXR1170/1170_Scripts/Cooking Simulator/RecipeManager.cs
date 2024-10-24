using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    // Start is called before the first frame update
    void Start()
    {
        ingredients.Add(new Ingredient("Red Cube", 0, Resources > AssetBundleLoadResult("Ingredients/RedCube") as GameObject, 3)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
