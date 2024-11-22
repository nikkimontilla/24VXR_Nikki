using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    public void OnMouseOver()
    {
        text.SetActive(true);
    }

    public void OnMouseExit()
    {
        text.SetActive(false);
    }
}
