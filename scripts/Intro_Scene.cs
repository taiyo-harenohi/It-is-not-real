using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_Scene : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
