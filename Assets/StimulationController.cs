using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LSL;

public class StimulationController : MonoBehaviour
{
    public bool active = true;
    public float duration = 1.0f;
    public float minTime = 3.0f;
    public float maxTime = 5.0f;
    private float initial = 0.0f;
    private bool flipflop = true;
    public Transform right;
    public Transform left;
    public GameObject square;
    public GameObject square2;
    public GameObject soundObject;
    private GameObject stimul;

    //LSL VARIABLES
    /*public string StreamName = "Unity.UnityStream";
    public string StreamType = "Unity.StreamType";
    public string StreamId = "MyStreamID-Unity1234";
    private StreamOutlet outlet;
    private string[] currentSample;*/


    // Start is called before the first frame update
    void Start()
    {
        //Create LSL stream
        /*StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 3, Time.fixedDeltaTime * 1000, LSL.channel_format_t.cf_float32);
        XMLElement chans = streamInfo.desc().append_child("channels");
        chans.append_child("channel").append_child_value("label", "Time");
        chans.append_child("channel").append_child_value("label", "Message");
        outlet = new StreamOutlet(streamInfo);
        currentSample = new string[2];*/
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true) {
            //Debug.Log("Active works");
            if (initial > 0.0f)
            {
                //Debug.Log("Initial works");
                initial = initial - Time.deltaTime;
            }
            else
            {
                //Debug.Log("Else works");
                if (flipflop == true)
                {
                    int randNum = UnityEngine.Random.Range(0, 3);
                    if (randNum == 1)
                    {
                        if (UnityEngine.Random.Range(0, 2) == 1)
                        {
                            stimul = Instantiate(square, right);
                        }
                        else
                        {
                            stimul = Instantiate(square2, right);
                        }
                    }
                    else if (randNum == 2)
                    {
                        if (UnityEngine.Random.Range(0, 2) == 1)
                        {
                            stimul = Instantiate(square, left);
                        }
                        else
                        {
                            stimul = Instantiate(square2, left);
                        }
                    }
                    else
                    {
                        stimul = Instantiate(soundObject, left);
                    }
                    initial = duration;
                    flipflop = false;

                    //Send LSL Stimulus creation
                    /*currentSample[1] = DateTime.Now;
                    currentSample[2] = "Stimulus created";
                    outlet.push_sample(currentSample);*/
                }
                else
                {
                    Destroy(stimul);
                    initial = UnityEngine.Random.Range(minTime, maxTime);
                    flipflop = true;

                    //Send LSL Stimulus deletion
                    /*currentSample[1] = DateTime.Now;
                    currentSample[2] = "Stimulus deleted";
                    outlet.push_sample(currentSample);*/
                }
            }
        }
    }
}
