using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
//using System.IO.Ports;

public class VideoPlay3 : MonoBehaviour
{

    public bool dPlaying = false;

    public GameObject V3_1;
    public GameObject V3_2;
    public GameObject V3_4;

    private VideoPlay1 VScript1;
    private VideoPlayer VPlayer1;

    private VideoPlay2 VScript2;
    private VideoPlayer VPlayer2;

    private VideoPlay4 VScript4;
    private VideoPlayer VPlayer4;

    private bool aPlayingOther;
    private bool sPlayingOther;
    private bool fPlayingOther;

    void Start()
    {
        VScript1 = V3_1.GetComponent<VideoPlay1>();
        VPlayer1 = V3_1.GetComponent<VideoPlayer>();

        VScript2 = V3_2.GetComponent<VideoPlay2>();
        VPlayer2 = V3_2.GetComponent<VideoPlayer>();

        VScript4 = V3_4.GetComponent<VideoPlay4>();
        VPlayer4 = V3_4.GetComponent<VideoPlayer>();
    }
    
    void Update()
    {
        aPlayingOther = VScript1.aPlaying;
        sPlayingOther = VScript2.sPlaying;
        fPlayingOther = VScript4.fPlaying;

        if (Input.GetKeyDown(KeyCode.D) && !dPlaying)
        {
            if (aPlayingOther)
            {
                VPlayer1.enabled = false;
                VScript1.aPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                dPlaying = true;
            }
            else if (sPlayingOther)
            {
                VPlayer2.enabled = false;
                VScript2.sPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                dPlaying = true;
            }
            else if (fPlayingOther)
            {
                VPlayer4.enabled = false;
                VScript4.fPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                dPlaying = true;
            }
            else
            {
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                dPlaying = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) && dPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().enabled = false;
            dPlaying = false;
        }




        if (Input.GetKeyDown(KeyCode.P) && dPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().Pause();
            dPlaying = false;
        } else if (Input.GetKeyDown(KeyCode.P) && !dPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().Play();
            dPlaying = true;
        }
        
    }
}