using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public InputField IPAddress;

    // Assign UpdateIP function to InputAddress field for both on value change and on end edit
    public void UpdateIP(string newstring)
    {
        PlayerPrefs.SetString("IP", newstring);
    }

    void Awake()
    {
        // if keys in player pref are not present, set default values
        IPAddress.text = PlayerPrefs.GetString("IP", "192.168.1.1");
       
    }
}

