using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;

public class playerSounds_control : MonoBehaviour
{
    //[FMODUnity.EventRef]
    public StudioEventEmitter eventEmitterRefHeartBeatNEW;
    private int fearamount;

    // Use this for initialization
    void Start()
    {

    }

    void awake()
    {
        eventEmitterRefHeartBeatNEW = GetComponent<StudioEventEmitter>();
        fearamount = LevelController.instance.GetFear();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void playHeartSFX(/*int amountfear*/)
    {/*
        if (amountfear > 0 && amountfear < 5)
        {
            heartSpeed("vlow");
        }
        else if (amountfear >= 5 && amountfear < 10)
        {
            heartSpeed("low");
        }
        else if (amountfear >= 10 && amountfear < 15)
        {
            heartSpeed("lmedium");
        }
        else if (amountfear >= 15 && amountfear < 20)
        {
            heartSpeed("medium");
        }
        else if (amountfear >= 20 && amountfear < 25)
        {
            heartSpeed("hmedium");
        }
        else if (amountfear >= 25 && amountfear < 30)
        {
            heartSpeed("high");
        }
        else if (amountfear >= 30)
        {
            heartSpeed("vhigh");
        }*/
        eventEmitterRefHeartBeatNEW.Play();

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

    public void heartSpeed(string speed){
        if (speed == "vlow") {
            eventEmitterRefHeartBeatNEW.SetParameter("pitch", 0);
            eventEmitterRefHeartBeatNEW.SetParameter("speed", 0f);
            Debug.Log("heartbeat Speed VLOW");
        }else if (speed == "low") {
            eventEmitterRefHeartBeatNEW.SetParameter("pitch", 1);
            eventEmitterRefHeartBeatNEW.SetParameter("speed", 0f);
            Debug.Log("heartbeat Speed LOW");
        }else if (speed == "lmedium") {
            eventEmitterRefHeartBeatNEW.SetParameter("pitch", 2);
            eventEmitterRefHeartBeatNEW.SetParameter("speed", 0f);
            Debug.Log("heartbeat Speed LMEDIUM");
        }else if (speed == "medium") {
            eventEmitterRefHeartBeatNEW.SetParameter("pitch", 0);
            eventEmitterRefHeartBeatNEW.SetParameter("speed", 1f);
            Debug.Log("heartbeat Speed MEDIUM");
        }else if (speed == "hmedium") {
            eventEmitterRefHeartBeatNEW.SetParameter("pitch", 1);
            eventEmitterRefHeartBeatNEW.SetParameter("speed", 1f);
            Debug.Log("heartbeat Speed HMEDIUM");
        }else if (speed == "high") {
            eventEmitterRefHeartBeatNEW.SetParameter("pitch", 2);
            eventEmitterRefHeartBeatNEW.SetParameter("speed", 1f);
            Debug.Log("heartbeat Speed HIGH");
        }else if (speed == "vhigh") {
            eventEmitterRefHeartBeatNEW.SetParameter("pitch", 3);
            eventEmitterRefHeartBeatNEW.SetParameter("speed", 1f);
            Debug.Log("heartbeat Speed VHIGH");
        }
    }
}
