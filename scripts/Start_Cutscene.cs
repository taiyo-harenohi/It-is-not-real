using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Start_Cutscene : MonoBehaviour
{
    public GameObject dialogWindow;
    public TextMeshProUGUI textWindow;
    private string[] lines;
    private int index = 1;
    private Vector3 cameraPos;
    private string fileName;

    public static bool isVisible = false;
    private bool isMid = false;

    void OnEnable()
    {
        SceneManager.sceneLoaded += IntroDialogue;    
    }

    public void IntroDialogue(Scene scene, LoadSceneMode mode)
    {
        string path = "Assets/Dialogues/tutorial/start_cutscene.txt";
        StreamReader reader = new StreamReader(path);

        // get file name
        fileName = Path.GetFileName(path);

        // reading until the end
        var fileContents = reader.ReadToEnd();
        reader.Close();

        // splitting on items whenever there is new line
        lines = fileContents.Split("\n"[0]);

        if (lines.Length != 0)
        {
            dialogWindow.SetActive(true);
            isVisible = true;
        }

        textWindow.text = lines[0];
    }

    private void Update()
    {
        // go through the stuff at the start of the scene
        if (Input.GetKeyDown(KeyCode.Space) && index < lines.Length)
        {
            if (index == 16 && fileName == "start_cutscene.txt")
            {
                // move camera to nearest tree
                cameraPos = Camera.main.transform.position;
                Debug.Log(Camera.main.transform.position);
                Vector3 newPos = Camera.main.transform.position;
                newPos.x = -7;
                newPos.z = -81;
                Camera.main.transform.position = newPos;
                Camera.main.orthographicSize = 5;
            }
            else if (index == 17 && fileName == "start_cutscene.txt")
            {
                Camera.main.transform.position = cameraPos;
                Camera.main.orthographicSize = 10;
            }
            textWindow.text = lines[index];
            index++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && index == lines.Length)
        {
            dialogWindow.SetActive(false);
            isVisible = false;
        }

        // if light_wood is picked up
        if (index == lines.Length && Goals_Score.resourcesNumber["light_wood"] != 0 && !isMid)
        {
            dialogWindow.SetActive(true);
            isVisible = true;
            MidTutorial();
            isMid = true;
        }
    }

    // TODO this -- a pak přejít na scénu po sebrání vody. Tady to zatím končí, protože nemám pond přetáhnut do hry :upside_down:
    void MidTutorial()
    {
        string path = "Assets/Dialogues/tutorial/mid_cutscene.txt";
        StreamReader reader = new StreamReader(path);

        // get file name
        fileName = Path.GetFileName(path);

        // reading until the end
        var fileContents = reader.ReadToEnd();
        reader.Close();

        Array.Clear(lines, 0, lines.Length);
        // splitting on items whenever there is new line
        lines = fileContents.Split("\n"[0]);

        textWindow.text = lines[0];
        index = 1;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= IntroDialogue;    
    }
}
