using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using System;

public class PointCloud_Projector : MonoBehaviour
{
    public PointCloudReceiver message;
    public float particle_size;

    public Text seq_count;

    private ParticleSystem mySystem;
    private ParticleSystem.Particle[] particles;
    private Vector3[] particlePositions;
    private int dataPoints;
    private int numParticles;

    public int seq;

    public float R;
    public float B;
    public float G;
    public float alpha;


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

    public void EnlargeParticles()
    {
        particle_size = particle_size + 0.001f;
        Display();
    }

    public void ShrinkParticles()
    {
        if (particle_size < 0)
        {
            particle_size = 0.001f;
        }
        else
        {
            particle_size = particle_size - 0.001f;
            Display();
        }
    }

    public void IncreaseAlpha()
    {
        alpha = alpha + 0.05f;
        Display();
    }

    public void DecreaseAlpha()
    {
        if (alpha < 0)
        {
            alpha = 0.01f;
        }
        else
        {
            alpha = alpha - 0.01f;
            Display();
        }
    }

    void Display()
    {
        
        //set positions
        for (int i = 0; i < numParticles; i++)
        {
            //image is inverted along x, multiply by -1 to y-compoment to correct. Pay attention to orientation of gameobject
            particles[i].position = new Vector3(message.points[i].x, -1.0f * message.points[i].y, message.points[i].z);
            //particles[i].startColor = Color.red;
            particles[i].startColor = new Color(R,B,G,alpha);

            particles[i].startSize = particle_size;  
        }
        
        mySystem.SetParticles(particles, particles.Length);

    }
}