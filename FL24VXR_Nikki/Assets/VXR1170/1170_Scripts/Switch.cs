using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour //ItemClick for Cooking Simulator
{
    public static int clickCount = 0;

    private void OnMouseDown()
    {
        clickCount++;
        Transform moveLoc;
        GameObject tmp = Instantiate(this.gameObject);
        Destroy(tmp.GetComponent<Switch>());

        switch (clickCount) //switch cases are more efficient than if statement conditions
        {
            case 1:
                tmp.name = "Pan Item 1";
                moveLoc = GameObject.Find("PanLoc1").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(1f, 1f, 1f);

                break;

            case 2:
                tmp.name = "Pan Item 2";
                moveLoc = GameObject.Find("PanLoc2").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(1f, 1f, 1f); // you can change the values here to adjust scale

                break;

            case 3:
                tmp.name = "Pan Item 3";
                moveLoc = GameObject.Find("PanLoc3").transform;

                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.transform.rotation;
                tmp.transform.localScale = new Vector3(1f, 1f, 1f);

                clickCount = 0;
                break;

        }
    }
    
}
