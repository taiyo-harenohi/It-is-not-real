using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Start_Cutscene : MonoBehaviour
{
    public GameObject dialogWindow;
    public GameObject textWindow;

    public 

    void Start()
    {
        dialogWindow.SetActive(true);


        string path = "Assets/start_cutscene.txt";
        StreamReader reader = new StreamReader(path);
        
        var fileContents = reader.ReadToEnd();
        var lines = fileContents.Split("\n"[0]);
        foreach (var line in lines)
        {
            Debug.Log(line);
        }
        reader.Close();
    }
}
