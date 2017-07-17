using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
//using System.IO.Ports;

public class VideoPlay2 : MonoBehaviour
{

    public bool sPlaying = false;

    public GameObject V2_1;
    public GameObject V2_3;
    public GameObject V2_4;

    private VideoPlay1 VScript1;
    private VideoPlayer VPlayer1;

    private VideoPlay3 VScript3;
    private VideoPlayer VPlayer3;

    private VideoPlay4 VScript4;
    private VideoPlayer VPlayer4;

    private bool aPlayingOther;
    private bool dPlayingOther;
    private bool fPlayingOther;

    void Start()
    {
        VScript1 = V2_1.GetComponent<VideoPlay1>();
        VPlayer1 = V2_1.GetComponent<VideoPlayer>();

        VScript3 = V2_3.GetComponent<VideoPlay3>();
        VPlayer3 = V2_3.GetComponent<VideoPlayer>();

        VScript4 = V2_4.GetComponent<VideoPlay4>();
        VPlayer4 = V2_4.GetComponent<VideoPlayer>();
    }
    
    void Update()
    {
        aPlayingOther = VScript1.aPlaying;
        dPlayingOther = VScript3.dPlaying;
        fPlayingOther = VScript4.fPlaying;

        if (Input.GetKeyDown(KeyCode.S) && !sPlaying)
        {
            if (aPlayingOther)
            {
                VPlayer1.enabled = false;
                VScript1.aPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                sPlaying = true;
            }
            else if (dPlayingOther)
            {
                VPlayer3.enabled = false;
                VScript3.dPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                sPlaying = true;
            }
            else if (fPlayingOther)
            {
                VPlayer4.enabled = false;
                VScript4.fPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                sPlaying = true;
            }
            else
            {
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                sPlaying = true;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.S) && sPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().enabled = false;
            sPlaying = false;
        }

        if (Input.GetKeyDown(KeyCode.P) && sPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().Pause();
            sPlaying = false;
        } else if (Input.GetKeyDown(KeyCode.P) && !sPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().Play();
            sPlaying = true;
        }
        
    }
}