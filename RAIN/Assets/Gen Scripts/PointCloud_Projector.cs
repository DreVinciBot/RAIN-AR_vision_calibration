using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using System;

public class PointCloud_Projector : MonoBehaviour
{
    public PointCloudReceiver message;

    public Text seq_count;

    private ParticleSystem mySystem;
    private ParticleSystem.Particle[] particles;
    private Vector3[] particlePositions;
    private int dataPoints;
    private int numParticles;

    public int seq;

    // Start is called before the first frame update
    void Start()
    {
        mySystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (message != null)
        {
            // Initialize variables 
            seq = message.seq;
            numParticles = message.numPoints;
            seq_count.text = " Seq: " + seq.ToString();
            particles = new ParticleSystem.Particle[numParticles];

            // Spawn 
            Display();
            //ColorChanger();
        }
    }

    void Display()
    {
        
        //set positions
        for (int i = 0; i < numParticles; i++)
        {
            //image is inverted along x, multiply by -1 to y-compoment to correct. Pay attention to orientation of gameobject
            particles[i].position = new Vector3(message.points[i].x, -1.0f * message.points[i].y, message.points[i].z);
            particles[i].startColor = Color.red;
            particles[i].startSize = 0.005f;  
        }
        

        //particles[0].position = new Vector3(0, 0, 0);

        mySystem.SetParticles(particles, particles.Length);

    }
}