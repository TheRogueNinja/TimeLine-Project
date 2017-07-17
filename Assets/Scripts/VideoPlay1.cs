using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlay1 : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600);
    public bool aPlaying = false;

    public GameObject V1_2;
    public GameObject V1_3;
    public GameObject V1_4;

    private VideoPlay2 VScript2;
    private VideoPlayer VPlayer2;
    
    private VideoPlay3 VScript3;
    private VideoPlayer VPlayer3;

    private VideoPlay4 VScript4;
    private VideoPlayer VPlayer4;
    
    private bool sPlayingOther;
    private bool dPlayingOther;
    private bool fPlayingOther;

    void Start()
    {
        if (!serialPort.IsOpen)
        {
            serialPort.Open();
        }

        VScript2 = V1_2.GetComponent<VideoPlay2>();
        VPlayer2 = V1_2.GetComponent<VideoPlayer>();

        VScript3 = V1_3.GetComponent<VideoPlay3>();
        VPlayer3 = V1_3.GetComponent <VideoPlayer>();

        VScript4 = V1_4.GetComponent<VideoPlay4>();
        VPlayer4 = V1_4.GetComponent<VideoPlayer>();

    }

    void Update()
    {
        sPlayingOther = VScript2.sPlaying;
        dPlayingOther = VScript3.dPlaying;
        fPlayingOther = VScript4.fPlaying;
        string temp = serialPort.ReadLine();
        int tempInt = int.Parse(temp);
        Debug.Log(temp);

        //if (Input.GetKeyDown(KeyCode.A) && !aPlaying)
        if (tempInt == 11 && !aPlaying)
        {
            if (sPlayingOther)
            {
                VPlayer2.enabled = false;
                VScript2.sPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                aPlaying = true;
            }
            else if (dPlayingOther)
            {
                VPlayer3.enabled = false;
                VScript3.dPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                aPlaying = true;
            }
            else if (fPlayingOther)
            {
                VPlayer4.enabled = false;
                VScript4.fPlaying = false;
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                aPlaying = true;
            }
            else
            {
                gameObject.GetComponent<VideoPlayer>().enabled = true;
                aPlaying = true;
            }
        }
        else if (tempInt == 1 && aPlaying)
        //else if (Input.GetKeyDown(KeyCode.A) && aPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().enabled = false;
            aPlaying = false;
        }




        if (Input.GetKeyDown(KeyCode.P) && aPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().Pause();
            aPlaying = false;
        } else if (Input.GetKeyDown(KeyCode.P) && !aPlaying)
        {
            gameObject.GetComponent<VideoPlayer>().Play();
            aPlaying = true;
        }
    }
}