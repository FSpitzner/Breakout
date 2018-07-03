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

    // Use this for initialization
    void Start()
    {
        heartEv = FMODUnity.RuntimeManager.CreateInstance(heartbeat);
        
        //createHeartEvInstance();
        
    }

    /*public void createHeartEvInstance()
    {
        heartEv.start();
    }*/

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
        heartEv.start();
        heartEv.setParameterValue("hasfear", 1f);
        heartSpeed("vlow");
        heartBeatOn = true;
    }

    public void heartSpeed(string speed)
    {
        if (speed == "vlow") { heartEv.setParameterValue("pitch", 0); heartEv.setParameterValue("speed", 0f); Debug.Log("heartbeat Speed VLOW"); }
        else if (speed == "low") { heartEv.setParameterValue("pitch", 1); heartEv.setParameterValue("speed", 0f); Debug.Log("heartbeat Speed LOW"); }
        else if (speed == "lmedium") { heartEv.setParameterValue("pitch", 2); heartEv.setParameterValue("speed", 0f); Debug.Log("heartbeat Speed LMEDIUM"); }
        else if (speed == "medium") { heartEv.setParameterValue("pitch", 0); heartEv.setParameterValue("speed", 1f); Debug.Log("heartbeat Speed MEDIUM"); }
        else if (speed == "hmedium") { heartEv.setParameterValue("pitch", 1); heartEv.setParameterValue("speed", 1f); Debug.Log("heartbeat Speed HMEDIUM"); }
        else if (speed == "high") { heartEv.setParameterValue("pitch", 2); heartEv.setParameterValue("speed", 1f); Debug.Log("heartbeat Speed HIGH"); }
        else if (speed == "vhigh") { heartEv.setParameterValue("pitch", 3); heartEv.setParameterValue("speed", 1f); Debug.Log("heartbeat Speed VHIGH"); }
    }

    //player has fear
    public void hasNOfear()
    {
        heartEv.setParameterValue("hasfear", 0f);
        heartEv.setParameterValue("pitch", 0);
        heartEv.setParameterValue("speed", 0f);
        heartEv.setTimelinePosition(0);
        heartEv.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        heartBeatOn = false;
    }


}
