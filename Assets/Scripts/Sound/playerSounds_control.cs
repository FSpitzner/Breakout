using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSounds_control : MonoBehaviour
{

    [FMODUnity.EventRef]
    




    //findet das Event in FMOD
    public string heartbeat = "event:/heartbeats/heartbeatsSystem_Event";

    FMOD.Studio.EventInstance heartEv;
    public bool heartBeatOn = false;
    int timelineposition;

    // Use this for initialization
    void Start()
    {
        heartEv = FMODUnity.RuntimeManager.CreateInstance(heartbeat);

        startHeartEv();

    }

    public void startHeartEv()
    {
        heartEv.start();
    }

    // Update is called once per frame
    void Update()
    {

    }


    /*
     * vlow
     * low
     * lowmedium
     * medium
     * highmedium
     * high
     * vhigh
     * */


    //player has fear
    public void hasfear()
    {
        //startHeartEv();
        heartEv.getTimelinePosition(out timelineposition);
       /* if ( timelineposition > 450){
        heartEv.setTimelinePosition(0);
        }*/
        heartEv.setParameterValue("hasfear", 1f);
        heartBeatOn = true;
    }
    

    public void heartSpeed(string speed)
    {
        heartEv.getTimelinePosition(out timelineposition);
        if (timelineposition > 450)
        {
            heartEv.setTimelinePosition(0);
        }
        if (speed == "vlow") {
                heartEv.setParameterValue("pitch", 0);
                heartEv.setParameterValue("speed", 0f);
                Debug.Log("heartbeat Speed VHIGH");
        }else if (speed == "low") {
            heartEv.setParameterValue("pitch", 0);
            heartEv.setParameterValue("speed", 0f);
            Debug.Log("heartbeat Speed VHIGH");
        }else if (speed == "lmedium") {
            heartEv.setParameterValue("pitch", 0);
            heartEv.setParameterValue("speed", 0f);
            Debug.Log("heartbeat Speed VHIGH");
        }else if (speed == "medium") {
            heartEv.setParameterValue("pitch", 0);
            heartEv.setParameterValue("speed", 0f);
            Debug.Log("heartbeat Speed VHIGH");
        }else if (speed == "hmedium") {
            heartEv.setParameterValue("pitch", 0);
            heartEv.setParameterValue("speed", 0f);
            Debug.Log("heartbeat Speed VHIGH");
        }else if (speed == "high") {
            heartEv.setParameterValue("pitch", 0);
            heartEv.setParameterValue("speed", 0f);
            Debug.Log("heartbeat Speed VHIGH");
        }else if (speed == "vhigh") {
            heartEv.setParameterValue("pitch", 0);
            heartEv.setParameterValue("speed", 0f);
            Debug.Log("heartbeat Speed VHIGH");
        }
    }

    //player has fear
    public void hasNOfear()
    {
        heartEv.setParameterValue("hasfear", 0f);
        heartEv.setParameterValue("pitch", 0);
        heartEv.setParameterValue("speed", 0f);
        //heartEv.setTimelinePosition(0);
        //heartEv.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        heartBeatOn = false;
    }


}
