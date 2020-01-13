using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class StatusManager : MonoBehaviour
{

    public Text statusText;
   // public HyperCubeTrackableEventHandler TrackerCube;
    public RosConnector rosConnection;

    public GameObject connector;
    public GameObject PointCloud;
    private Subscriber[] scripts;

	// Use this for initialization
	void Awake ()
    {
        statusText.text = "Initializing...";
        rosConnection.RosBridgeServerUrl = "ws://" + PlayerPrefs.GetString("IP", "192.168.1.1") + ":9090";

        // Initialize array for rosconnections
        scripts = new Subscriber[0];
        scripts = connector.GetComponents<Subscriber>();

    }

    // Update is called once per frame
    void Update ()
    {
        //checkTracker();
        //controlExtendedTracking();
        //implementPreferences();
	}

    void displayStatus (string message)
    {
        statusText.text = message;
    }

    /*
    void checkTracker()
    {
        if (TrackerCube.isTracked) {
            if (TrackerCube.isExtended)
                displayStatus("Target Image Lost, Extrapolating...");
            else
                displayStatus("Target Image Detected");
        }
        else
        {
            displayStatus("Target Image Not Found");
        }
    }
    

    void implementPreferences()
    {
        if (PlayerPrefs.GetInt("PointCloud", 1) == 1)
        {
            PointCloud.SetActive(true);
            //rosSubscriber("/ARFUROS/PointCloud2", true);
            //rosSubscriber("/ARFUROS/3DPointArray", true);
        }
        else
        {
            PointCloud.SetActive(false);
            //rosSubscriber("/ARFUROS/PointCloud2", false);
            //rosSubscriber("/ARFUROS/3DPointArray", false);
        }

    }

    */
    void rosSubscriber(string topic, bool status)
    {
          for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i].Topic == topic)
                    scripts[i].enabled = status;
            }
    }
   
}

