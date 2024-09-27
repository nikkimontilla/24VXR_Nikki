using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererComponent : MonoBehaviour
{
    // Declare variable
    private Renderer theRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Call Renderer component
        theRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // The renderer can change the object's material and color - use UP and DOWN keys in this case
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            theRenderer.material.color = Color.yellow; //Access material to change colour to yellow
            theRenderer.material.SetFloat("_Metallic", 0.9f); //Access material to change texture into metalic
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            theRenderer.material.color = Color.gray; //Access material to change colour back to default gray
            theRenderer.material.SetFloat("_Metallic", 0f); //Access material to change texture into default 
        }
        // The renderer makes the object visible and invisible - use ESC and SPACE BAR in this case
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            theRenderer.enabled = false; //Set enabled to false to make object disappear
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            theRenderer.enabled = true; //Set enabled to false to make object visible

        }
    }
}
