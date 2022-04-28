using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }

    public void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(1);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
