using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyManager : MonoBehaviour
{
    //public float to control in the inspector
    public float skySpeed;

    // Update is called once per frame
    void Update()
    {
        //Update every frame
        RenderSettings.skybox.SetFloat("_Rotation", Time.time*skySpeed);
    }
}
