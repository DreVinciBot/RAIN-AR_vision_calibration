using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Option_Menu()
    {
        SceneManager.LoadScene("Options_scene");
    }

    public void Quit_App()
    {
        Debug.Log("Exiting App!");
        Application.Quit();
    }

}