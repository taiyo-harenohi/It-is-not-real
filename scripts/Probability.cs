using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : MonoBehaviour
{

    public static Dictionary<string, int> probabilityPlatform = new Dictionary<string, int>();

    void Start()
    {
        probabilityPlatform.Add("nothing", 0);
        probabilityPlatform.Add("light_wood", 60);
        probabilityPlatform.Add("water", 100);
    }
}
