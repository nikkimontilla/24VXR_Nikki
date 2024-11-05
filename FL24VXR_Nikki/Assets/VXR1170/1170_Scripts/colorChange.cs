using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer == null)
        {
            Debug.Log("No Renderer Component found");
        }
    }

    public void colorChanger()
    {
        if (objectRenderer != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            objectRenderer.material.color = randomColor;
        }
        else
        {
            Debug.LogWarning("No Renderer Component found");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
