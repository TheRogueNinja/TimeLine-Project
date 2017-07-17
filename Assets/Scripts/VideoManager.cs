using UnityEngine;
using UnityEngine.Video;
using System.IO.Ports;
using System.Collections;

public class VideoManager : MonoBehaviour {
    
    SerialPort serialPort = new SerialPort("COM4", 9600);
    public bool aPlaying = false;
    public bool sPlaying = false;
    public bool dPlaying = false;
    public bool fPlaying = false;
    bool canFade = false;

    public GameObject obj;
    public Transform CamPos;
    public GameObject V1_1;
    public GameObject V1_2;
    public GameObject V1_3;
    public GameObject V1_4;
    
    private VideoPlayer VPlayer1;
    
    private VideoPlayer VPlayer2;
    
    private VideoPlayer VPlayer3;
    
    private VideoPlayer VPlayer4;
    private Color alphaColor;
    private float timeToFade = 3f;

    void Start()
    {
        if (!serialPort.IsOpen)
        {
            serialPort.Open();
        }
        //canFade = false;
        //alphaColor = obj.GetComponent<MeshRenderer>().material.color;
        //alphaColor.a = 0;

        VPlayer1 = V1_1.GetComponent<VideoPlayer>();

        VPlayer2 = V1_2.GetComponent<VideoPlayer>();

        VPlayer3 = V1_3.GetComponent<VideoPlayer>();

        VPlayer4 = V1_4.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        string temp = serialPort.ReadLine();
        Debug.Log(temp);
        string[] finalValues = temp.Split(',');
        if (int.Parse(finalValues[0]) < 300 && !aPlaying)
        {
            DisableAllVideo(0);
            //VPlayer1.enabled = true;
            //aPlaying = true;
            //finalValues[1] = "0";
            //finalValues[2] = "0";
            //finalValues[3] = "0";
        }
        //else
        //{
        //    V1_1.GetComponent<VideoPlayer>().enabled = false;
        //    aPlaying = false;
        //}

        if (int.Parse(finalValues[1]) < 300 && !sPlaying)
        {
            DisableAllVideo(1);
            //V1_2.GetComponent<VideoPlayer>().enabled = true;
            //sPlaying = true;
            //finalValues[0] = "0";
            //finalValues[2] = "0";
            //finalValues[3] = "0";
        }
        //else
        //{
        //    V1_2.GetComponent<VideoPlayer>().enabled = false;
        //    sPlaying = false;
        //}

        if (int.Parse(finalValues[2]) < 300 && !dPlaying)
        {
            DisableAllVideo(2);
            //V1_3.GetComponent<VideoPlayer>().enabled = true;
            //dPlaying = true;
            //finalValues[0] = "0";
            //finalValues[1] = "0";
            //finalValues[3] = "0";
        }
        //else
        //{
        //    V1_3.GetComponent<VideoPlayer>().enabled = false;
        //    dPlaying = false;
        //}

        if (int.Parse(finalValues[3]) < 300 && !fPlaying)
        {
            DisableAllVideo(3);
            //V1_4.GetComponent<VideoPlayer>().enabled = true;
            //fPlaying = true;
            //finalValues[0] = "0";
            //finalValues[1] = "0";
            //finalValues[2] = "0";
        }
        //else
        //{
        //    V1_4.GetComponent<VideoPlayer>().enabled = false;
        //    fPlaying = false;
        //}

        //else
        //{
        //    if (int.Parse(finalValues[0]) > 300)
        //    {
        //        VPlayer1.enabled = false;
        //        aPlaying = false;
        //    }
        //    if (int.Parse(finalValues[1]) > 300)
        //    {
        //        VPlayer2.enabled = false;
        //        sPlaying = false;
        //    }
        //    if (int.Parse(finalValues[2]) > 300)
        //    {
        //        VPlayer3.enabled = false;
        //        dPlaying = false;
        //    }
        //    if (int.Parse(finalValues[3]) > 300)
        //    {
        //        VPlayer4.enabled = false;
        //        fPlaying = false;
        //    }

        //}

    }

    private void DisableAllVideo(int currentVideo)
    {
        switch (currentVideo)
        {
            case 0:
                CamPos.transform.position = new Vector3(0, 0, -5200);
                //StartCoroutine(WaitLogic(1.5f));
                //canFade = true;
                VPlayer1.enabled = true;
                aPlaying = true;

                VPlayer2.enabled = false;
                sPlaying = false;

                VPlayer3.enabled = false;
                dPlaying = false;

                VPlayer4.enabled = false;
                fPlaying = false;
                break;

            case 1:
                CamPos.transform.position = new Vector3(19200, 0, -5200);
                //StartCoroutine(WaitLogic(1.5f));
                //obj.GetComponent<MeshRenderer>().material.color = Color.Lerp(obj.GetComponent<MeshRenderer>().material.color, alphaColor, timeToFade * Time.deltaTime);
                //Debug.Log(obj.GetComponent<MeshRenderer>().material.color);
                VPlayer2.enabled = true;
                sPlaying = true;

                VPlayer1.enabled = false;
                aPlaying = false;

                VPlayer3.enabled = false;
                dPlaying = false;

                VPlayer4.enabled = false;
                fPlaying = false;
                break;

            case 2:
                CamPos.transform.position = new Vector3(38400, 0, -5200);
                //StartCoroutine(WaitLogic(1.5f));
                VPlayer3.enabled = true;
                dPlaying = true;

                VPlayer1.enabled = false;
                aPlaying = false;

                VPlayer2.enabled = false;
                sPlaying = false;

                VPlayer4.enabled = false;
                fPlaying = false;
                break;

            case 3:
                CamPos.transform.position = new Vector3(57600, 0, -5200);
                VPlayer4.enabled = true;
                fPlaying = true;

                VPlayer1.enabled = false;
                aPlaying = false;

                VPlayer2.enabled = false;
                sPlaying = false;

                VPlayer3.enabled = false;
                dPlaying = false;
                break;


        }
        //VPlayer1.enabled = false;
        //aPlaying = false;

        //VPlayer2.enabled = false;
        //sPlaying = false;

        //VPlayer3.enabled = false;
        //dPlaying = false;

        //VPlayer4.enabled = false;
        //fPlaying = false;

    }
    //IEnumerator WaitLogic(float waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime);
    //}
}
