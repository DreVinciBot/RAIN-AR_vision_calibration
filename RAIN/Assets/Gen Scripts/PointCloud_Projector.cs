using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RosSharp.RosBridgeClient;
using System;

public class PointCloud_Projector : MonoBehaviour
{
    public PointCloudReceiver message;
    public float particle_size;
    public Slider Red_slider;
    public Slider Green_slider;
    public Slider Blue_slider;

    public Text seq_count;
    public Text ps_value;
    public Text alpha_text;

    private ParticleSystem mySystem;
    private ParticleSystem.Particle[] particles;
    private Vector3[] particlePositions;
    private int dataPoints;
    private int numParticles;

    public int seq;

    public float R;
    public float B;
    public float G;
    public float alpha_value;


    // Start is called before the first frame update
    void Start()
    {
        mySystem = GetComponent<ParticleSystem>();
        particle_size = float.Parse(ps_value.text, System.Globalization.CultureInfo.InvariantCulture);
        alpha_value = float.Parse(alpha_text.text, System.Globalization.CultureInfo.InvariantCulture);
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
          
        }
    }

    public void EnlargeParticles()
    {
        particle_size = (float)System.Math.Round(particle_size + 0.001f,3);
        ps_value.text = particle_size.ToString();
        Display();
    }

    public void ShrinkParticles()
    {
        if (particle_size < 0)
        {
            particle_size = 0.001f;
            ps_value.text = particle_size.ToString();
        }
        else
        {
            particle_size = (float)System.Math.Round(particle_size - 0.001f,3);
            ps_value.text = particle_size.ToString();
            Display();
        }
    }

    public void IncreaseAlpha()
    {
        alpha_value = (float)System.Math.Round(alpha_value + 0.01f,2);
        alpha_text.text = alpha_value.ToString();
        Display();
    }

    public void DecreaseAlpha()
    {
        if (alpha_value < 0)
        {
            alpha_value = 0.01f;
            alpha_text.text = alpha_value.ToString();
        }
        else
        {
            alpha_value = (float)System.Math.Round(alpha_value - 0.01f,2);
            alpha_text.text = alpha_value.ToString();
            Display();
        }
    }

    public void Red_value(float r_value)
    {
        R = r_value;
        Display();
    }

    public void Green_value(float g_value)
    {
        G = g_value;
        Display();
    }

    public void Blue_value(float b_value)
    {
        B = b_value;
        Display();
    }

    void Display()
    {
        
        //set positions
        for (int i = 0; i < numParticles; i++)
        {
            //image is inverted along x, multiply by -1 to y-compoment to correct. Pay attention to orientation of gameobject
            particles[i].position = new Vector3(message.points[i].x, -1.0f * message.points[i].y, message.points[i].z);
            particles[i].startColor = new Color(R,G,B,alpha_value);
            particles[i].startSize = particle_size;  
        }
        
        mySystem.SetParticles(particles, particles.Length);

    }
}