using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
//using System.IO.Ports;

public class VideoPlay4 : MonoBehaviour
{

    public bool fPlaying = false;

    public GameObject V4_1;
    public GameObject V4_2;
    public GameObject V4_3;

    private VideoPlay1 VScript1;
    private VideoPlayer VPlayer1;

    private VideoPlay2 VScript2;
    private VideoPlayer VPlayer2;

    private VideoPlay3 VScript3;
    private VideoPlayer VPlayer3;

    private bool aPlayingOther;
    private bool sPlayingOther;
    private bool dPlayingOther;

    void Start()
    {
        VScript1 = V4_1.GetComponent<VideoPlay1>();
        VPlayer1 = V4_1.GetComponent<VideoPlayer>();

        VScript2 = V4_2.GetComponent<VideoPlay2>();
        VPlayer2 = V4_2.GetComponent<VideoPlayer>();

        VScript3 = V4_3.GetComponent<VideoPlay3>();
        VPlayer3 = V4_3.GetComponent<VideoPlayer>();
    }
    
    void Update()
    {

        aPlayingOther = VScript1.aPlaying;
        sPlayingOther = VScript2.sPlaying;
        dPlayingOther = VScript3.dPlaying;

        if (Input.GetKeyDown(KeyCode.F) && !fPlaying)
        {
            if (aPlayingOther)
            {
                VPlayer1.enabled = false;
                VScript1.aPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                fPlaying = true;
            }
            else if (sPlayingOther)
            {
                VPlayer2.enabled = false;
                VScript2.sPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                fPlaying = true;
            }
            else if (dPlayingOther)
            {
                VPlayer3.enabled = false;
                VScript3.dPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                fPlaying = true;
            }
            else
            {
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                fPlaying = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.F) && fPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().enabled = false;
            fPlaying = false;
        }



        if (Input.GetKeyDown(KeyCode.P) && fPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().Pause();
            fPlaying = false;
        } else if (Input.GetKeyDown(KeyCode.P) && !fPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().Play();
            fPlaying = true;
        }
        
    }
}