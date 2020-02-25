using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video; 

public class PlayVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public Animator animator;

    public double time;
    public double currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        time = gameObject.GetComponent<VideoPlayer>().clip.length-1.0f;
        StartCoroutine(Playvideo());
        //animator.StopPlayback();
    }

    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;

        if (currentTime >= time)
        {
            animator.SetTrigger("Start_trigger");
        }
    }

    IEnumerator Playvideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);

        while(!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();


        
    }
}
