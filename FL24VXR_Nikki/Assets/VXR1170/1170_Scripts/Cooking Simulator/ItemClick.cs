using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

//This class controls player interaction
public class ItemClick : MonoBehaviour
{
    private Vector3 ogIngredientLocation;
    private Vector3 firstPanLocation = new Vector3(-1.48000002f, 3.19283342f, -0.224351496f);
    private Vector3 secondPanLocation = new Vector3(-0.00999999978f, 3.19283342f, -0.224351496f);
    private Vector3 thirdPanLocation = new Vector3(1.44000006f, 3.19283342f, -0.224351496f);
    private bool inOGIngredientLocation = true;

    private bool isClicked = false;

    private void OnMouseDown()
    {

        if (isClicked)
        {
            transform.position = firstPanLocation;
            inOGIngredientLocation = false;
        }
       




    }
    //clickCount func tracks the number of ingredients selected onto the pan; control the limit to 3

    //OnMouseDown

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
