using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public InputField IPAddress;
    //public Toggle PointCloud;

    public void UpdateIP(string newstring)
    {
        PlayerPrefs.SetString("IP", newstring);
    }

    /*
    public void UpdatePointCloud(bool newbool)
    {
        int val = newbool ? 1 : 0;
        PlayerPrefs.SetInt("PointCloud", val);
    }
    

    public void OnApply()
    {
        SceneManager.LoadScene("arview");
    }
    */

    void Awake()
    {
        // Load in the values
        // if keys in player pref are not present, set default values
        IPAddress.text = PlayerPrefs.GetString("IP", "192.168.1.1");
        /*
        if (PlayerPrefs.GetInt("PointCloud", 1) == 1)
            PointCloud.isOn = true;
        else
            PointCloud.isOn = false;

        
        if (PlayerPrefs.GetInt("LaserScan", 1) == 1)
            LaserScan.isOn = true ;
        else 
        	LaserScan.isOn = false;

        if (PlayerPrefs.GetInt("GlobalPath", 1) == 1)
            GlobalPath.isOn = true;
        else 
        	GlobalPath.isOn = false;

        if (PlayerPrefs.GetInt("PeopleTracking", 1) == 1)
            PeopleTracking.isOn = true;
        else
            PeopleTracking.isOn = false;

        if (PlayerPrefs.GetInt("Costmap", 1) == 1)
            Costmap.isOn = true ;
        else 
            Costmap.isOn = false;

        if (PlayerPrefs.GetInt("LocalizationParticles", 1) == 1)
            LocalizationParticles.isOn = true ;
        else 
            LocalizationParticles.isOn = false;
            
        if (PlayerPrefs.GetInt("FullPath", 1) == 1)
            FullPath.isOn = true ;
        else 
            FullPath.isOn = false;

        if (PlayerPrefs.GetInt("Blinker", 1) == 1)
            Blinker.isOn = true ;
        else 
            Blinker.isOn = false;

        */
    }
}

