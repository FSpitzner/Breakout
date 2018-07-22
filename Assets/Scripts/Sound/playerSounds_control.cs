using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;

public class playerSounds_control : MonoBehaviour
{
    //[FMODUnity.EventRef]
    public StudioEventEmitter eventEmitterRefHeartBeat;
    public Fear fear;

    public StudioEventEmitter eventEmitterRefThunderSMALL;
    public StudioEventEmitter eventEmitterRefThunderBIG;
//    public StudioEventEmitter eventEmitterRefThunderSMALL;
//    public StudioEventEmitter eventEmitterRefThunderSMALL;


    // Use this for initialization
    void Start()
    {

    }

    void awake()
    {
        eventEmitterRefHeartBeat = GetComponent<StudioEventEmitter>();

        eventEmitterRefThunderSMALL = GetComponent<StudioEventEmitter>();
        eventEmitterRefThunderBIG = GetComponent<StudioEventEmitter>();
    }


    // Update is called once per frame
    void Update()
    {
        //fearamount = LevelController.instance.GetFear();
    }

    public void playHeartSFX(/*int amountfear*/)
    {
        
        if (this.fear.fear > 0 && fear.fear < 5)
        {
            heartSpeed("vlow");
        }
        else if (fear.fear >= 5 && fear.fear < 10)
        {
            heartSpeed("low");
        }
        else if (fear.fear >= 10 && fear.fear < 15)
        {
            heartSpeed("lmedium");
        }
        else if (fear.fear >= 15 && fear.fear < 20)
        {
            heartSpeed("medium");
        }
        else if (fear.fear >= 20 && fear.fear < 25)
        {
            heartSpeed("hmedium");
        }
        else if (fear.fear >= 25 && fear.fear < 30)
        {
            heartSpeed("high");
        }
        else if (fear.fear >= 30)
        {
            heartSpeed("vhigh");
        }
        eventEmitterRefHeartBeat.Play();

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
            //eventEmitterRefHeartBeatNEW.SetParameter("pitch", 0);
            eventEmitterRefHeartBeat.SetParameter("speed", 0f);
            Debug.Log("heartbeat Speed VLOW");
        }else if (speed == "low") {
            //eventEmitterRefHeartBeatNEW.SetParameter("pitch", 1);
            eventEmitterRefHeartBeat.SetParameter("speed", 1f);
            Debug.Log("heartbeat Speed LOW");
        }else if (speed == "lmedium") {
            //eventEmitterRefHeartBeatNEW.SetParameter("pitch", 2);
            eventEmitterRefHeartBeat.SetParameter("speed", 2f);
            Debug.Log("heartbeat Speed LMEDIUM");
        }else if (speed == "medium") {
            //eventEmitterRefHeartBeatNEW.SetParameter("pitch", 0);
            eventEmitterRefHeartBeat.SetParameter("speed", 3f);
            Debug.Log("heartbeat Speed MEDIUM");
        }else if (speed == "hmedium") {
            //eventEmitterRefHeartBeatNEW.SetParameter("pitch", 1);
            eventEmitterRefHeartBeat.SetParameter("speed", 4f);
            Debug.Log("heartbeat Speed HMEDIUM");
        }else if (speed == "high") {
            //eventEmitterRefHeartBeatNEW.SetParameter("pitch", 2);
            eventEmitterRefHeartBeat.SetParameter("speed", 5f);
            Debug.Log("heartbeat Speed HIGH");
        }else if (speed == "vhigh") {
            //eventEmitterRefHeartBeatNEW.SetParameter("pitch", 3);
            eventEmitterRefHeartBeat.SetParameter("speed", 6f);
            Debug.Log("heartbeat Speed VHIGH");
        }
    }

    public void playThunder(int thunderID)
    {//thunderID: 0=small thunder; higher number bigger thunder
        if (thunderID == 0)
        {
            eventEmitterRefThunderSMALL.Play();
        }
        else if (thunderID == 1)
        {
            eventEmitterRefThunderBIG.Play();
        }
    }
}
