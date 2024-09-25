using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererComponent : MonoBehaviour
{
    // Declare and call renderer component
    public Renderer theRenderer;

    // Start is called before the first frame update
    void Start()
    {
        theRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // The renderer can change the object's material and color

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            theRenderer.material.SetColor("_Color", Color.yellow);
            theRenderer.material.SetFloat("_Metallic", 0.9f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            theRenderer.material.SetColor("_Color", Color.white);
            theRenderer.material.SetFloat("_Metallic", 0f);
        }
        // The renderer makes the object invisible
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            theRenderer.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            theRenderer.enabled = true;

        }
    }
}
