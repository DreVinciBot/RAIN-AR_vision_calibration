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

    public void PointArray_Raw_scene()
    {
        SceneManager.LoadScene("PointArray_Raw");
    }

    public void PointArray_Cylinder_scene()
    {
        SceneManager.LoadScene("PointArray_Cylinder");
    }

    public void MainMenu_scene()
    {
        SceneManager.LoadScene("MainMenu_scene");
    }

    public void MainMenu_No_Animation_Scene()
    {
        SceneManager.LoadScene("MainMenu_No_Animation_scene");
    }

}
