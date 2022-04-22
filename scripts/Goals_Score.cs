using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Goals_Score : MonoBehaviour
{
    public static Dictionary<string, int> resourcesNumber = new Dictionary<string, int>();

    private Dictionary<string, int> firstGoal = new Dictionary<string, int>();
    private Dictionary<string, int> secondGoal = new Dictionary<string, int>();
    private Dictionary<string, int> thirdGoal = new Dictionary<string, int>();
    private Dictionary<string, int> fourthGoal = new Dictionary<string, int>();
    private Dictionary<string, int> fifthGoal = new Dictionary<string, int>();
    private Dictionary<string, int> sixthGoal = new Dictionary<string, int>();
    private Dictionary<string, int> seventhGoal = new Dictionary<string, int>();

    public GameObject goalDialog;

    public static int goalChecking = 1;
    void Start()
    {
        resourcesNumber.Add("water", 0);
        resourcesNumber.Add("light_wood", 0);


        // w  - 10
        // lw - 10
        firstGoal.Add("water", 10);
        firstGoal.Add("light_wood", 10);
        
        // w  - 30
        // lw - 40
        secondGoal.Add("water", 30);
        secondGoal.Add("light_wood", 40);
        
        // w  - 60
        // lw - 70
        // r  - 20
        thirdGoal.Add("water", 60);
        thirdGoal.Add("light_wood", 70);
        thirdGoal.Add("rocks", 20);
        
        fourthGoal.Add("water", 50);
        fourthGoal.Add("light_wood", 110);
        fourthGoal.Add("rocks", 50);
        
        fifthGoal.Add("water", 60);
        fifthGoal.Add("light_wood", 70);
        fifthGoal.Add("rocks", 20);
        fifthGoal.Add("dark_wood", 50);
        
        sixthGoal.Add("water", 80);
        sixthGoal.Add("light_wood", 30);
        sixthGoal.Add("rocks", 50);
        sixthGoal.Add("dark_wood", 60);

        seventhGoal.Add("water", 30);
        seventhGoal.Add("light_wood", 50);
        seventhGoal.Add("rocks", 60);
        seventhGoal.Add("dark_wood", 40);
        seventhGoal.Add("animal", 100);

    }

    void Update()
    {
        if (!Start_Cutscene.isVisible)
        {
            GoalCheck();
        }
    }

    void GoalCheck()
    {
        if (resourcesNumber["water"] >= firstGoal["water"] && resourcesNumber["light_wood"] >= firstGoal["light_wood"] && goalChecking == 1)
        {
            goalChecking = 2;
            goalDialog.SetActive(true);
            StartCoroutine(GoalTime());

        }
        
        if (resourcesNumber["water"] >= secondGoal["water"] && resourcesNumber["light_wood"] >= secondGoal["light_wood"] && goalChecking == 2)
        {
            goalChecking = 3;
            goalDialog.SetActive(true);
            StartCoroutine(GoalTime());

        }
        
        if (resourcesNumber["water"] >= thirdGoal["water"] && resourcesNumber["light_wood"] >= thirdGoal["light_wood"] && 
            resourcesNumber["rocks"] >= thirdGoal["rocks"] && goalChecking == 3)
        {
            goalChecking = 4;
            goalDialog.SetActive(true);
            StartCoroutine(GoalTime());

        }

        if (resourcesNumber["water"] >= fourthGoal["water"] && resourcesNumber["light_wood"] >= fourthGoal["light_wood"] && 
            resourcesNumber["rocks"] >= fourthGoal["rocks"] && goalChecking == 4)
        {
            goalChecking = 5;
            goalDialog.SetActive(true);
            StartCoroutine(GoalTime());

        }
        
        if (resourcesNumber["water"] >= fifthGoal["water"] && resourcesNumber["light_wood"] >= fifthGoal["light_wood"] && 
            resourcesNumber["rocks"] >= fifthGoal["rocks"] && resourcesNumber["dark_wood"] >= fifthGoal["dark_wood"] && goalChecking == 5)
        {
            goalChecking = 6;
            goalDialog.SetActive(true);
            StartCoroutine(GoalTime());

        }
        if (resourcesNumber["water"] >= sixthGoal["water"] && resourcesNumber["light_wood"] >= sixthGoal["light_wood"] && 
            resourcesNumber["rocks"] >= sixthGoal["rocks"] && resourcesNumber["dark_wood"] >= sixthGoal["dark_wood"] && goalChecking == 6)
        {
            goalChecking = 7;
            goalDialog.SetActive(true);
            StartCoroutine(GoalTime());

        }
        
        if (resourcesNumber["water"] >= seventhGoal["water"] && resourcesNumber["light_wood"] >= seventhGoal["light_wood"] && 
            resourcesNumber["rocks"] >= seventhGoal["rocks"] && resourcesNumber["dark_wood"] >= seventhGoal["dark_wood"] && 
            resourcesNumber["animals"] >= seventhGoal["animals"] && goalChecking == 7)
        {
            goalChecking = 8;
            goalDialog.SetActive(true);
            StartCoroutine(GoalTime());

        }
    }

    IEnumerator GoalTime()
    {
        yield return new WaitForSeconds(5);
        goalDialog.SetActive(false);
        Expanding_Map.ProbabilityUpCheck();
    }
}