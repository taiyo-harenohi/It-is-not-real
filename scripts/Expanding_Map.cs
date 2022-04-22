using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expanding_Map : MonoBehaviour
{

    public GameObject[] platforms = new GameObject[7];
    public Transform arrow;

    public static int limitMax;
    void OnMouseDown()
    {
        Invoke("SpawnPlatform", 0f);
    }

    void SpawnPlatform()
    {
        System.Random r = new System.Random();

        int generate = r.Next(0, 100);

        if (generate > 0 && generate <= Probability.probabilityPlatform["nothing"])
        {
            Instantiate(platforms[0], arrow.position, arrow.rotation);
        }
        else if (generate > Probability.probabilityPlatform["nothing"] && generate <= Probability.probabilityPlatform["light_wood"])
        {
            Instantiate(platforms[1], arrow.position, arrow.rotation);
        }
        else if (generate > Probability.probabilityPlatform["light_wood"] && generate <= Probability.probabilityPlatform["water"])
        {
            Instantiate(platforms[2], arrow.position, arrow.rotation);
        }
        Destroy(this.gameObject);
    }


    public static void ProbabilityUpCheck()
    {
        switch(Goals_Score.goalChecking)
        {
            case 2: 
                Probability.probabilityPlatform["nothing"] = 4;
                Probability.probabilityPlatform["light_wood"] = 45;
                Probability.probabilityPlatform["water"] = 100;
                break;
            case 3:
                Probability.probabilityPlatform["nothing"] = 6;
                Probability.probabilityPlatform["light_wood"] = 40;
                Probability.probabilityPlatform["water"] = 80;
                Probability.probabilityPlatform.Add("rocks", 100);
                break;
        }
    }
}
