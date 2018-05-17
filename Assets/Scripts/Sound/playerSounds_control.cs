using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSounds_control : MonoBehaviour
{

    [FMODUnity.EventRef]

    //findet das Event in FMOD
    public string heartbeat = "event:/playerSounds/heartbeat";

    FMOD.Studio.EventInstance heartEv;

    // Use this for initialization
    void Start()
    {
        heartEv = FMODUnity.RuntimeManager.CreateInstance(heartbeat);
        heartEv.start();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //player has fear
    public void hasfear()
    {
        heartEv.setParameterValue("FearOnOff", 1f);
    }

    //player has fear
    public void hasNOfear()
    {
        heartEv.setParameterValue("FearOnOff", 0f);
    }

    //defines amount of fear
    public void fearLevelLow()
    {
        heartEv.setParameterValue("Fear", 0f);
    }
    //defines amount of fear
    public void fearLevelMedium()
    {
        heartEv.setParameterValue("Fear", 1f);
    }
    //defines amount of fear
    public void fearLevelHigh()
    {
        heartEv.setParameterValue("Fear", 2f);
    }


}
