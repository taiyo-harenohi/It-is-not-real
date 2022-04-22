using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pick_Resources : MonoBehaviour
{
    // holding down the mouse == picking up resources
    //private float mouseHeldTime = 0;

    // text showing
    public TextMeshProUGUI resourceWaterText;
    public TextMeshProUGUI resourceLightWoodText;
    public TextMeshProUGUI resourceRocksText;


    private int resourcesWater;
    private int resourcesLightWood;
    private int resourcesRocks;

    void Update()
    {   
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null)
            {
                if (hit.transform.gameObject.tag == "water" || hit.transform.gameObject.tag == "light_wood" || hit.transform.gameObject.tag == "rocks")
                {
                    TextChange(hit.transform.gameObject);
                    Destroy(hit.transform.gameObject);
                    //mouseHeldTime = 0f;
                }
            }
        }
    }

    // method for changing text
    void TextChange(GameObject item)
    {
        System.Random r = new System.Random();

        // look out for overlapping layers !!!
        if (item.tag == "water")
        {
            resourcesWater += r.Next(5, 15);
            Goals_Score.resourcesNumber["water"] = resourcesWater;
            resourceWaterText.text = Goals_Score.resourcesNumber["water"].ToString();
        }
        else if (item.tag == "light_wood")
        {
            resourcesLightWood += r.Next(4, 10);
            Goals_Score.resourcesNumber["light_wood"] = resourcesLightWood;
            resourceLightWoodText.text = Goals_Score.resourcesNumber["light_wood"].ToString();
        }
        else if (item.tag == "rocks")
        {
            resourcesRocks += r.Next(1, 4);
            Goals_Score.resourcesNumber["rocks"] = resourcesRocks;
            resourceRocksText.text = Goals_Score.resourcesNumber["rocks"].ToString();
        }
    }
}
