﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;
using FMOD.Studio;


public class playerSounds_control : MonoBehaviour
{
    //[FMODUnity.EventRef]
    public StudioEventEmitter eventEmitterRefHeartBeat;
    public StudioEventEmitter eventEmitterRefAmbientIngameMusic;
    public StudioEventEmitter eventEmitterRefMenuMusic;
    public StudioEventEmitter eventEmitterRefDoorOPENCreak;
    public StudioEventEmitter eventEmitterRefDoorCLOSECreak;

    public EventInstance MenuMusic;
    public Fear fear;

    private bool MenuMusicPlaybackState;
    private Random doorSoundSelector;

    //public StudioEventEmitter eventEmitterRefThunder;


    // Use this for initialization
    void Start()
    {

    }

    void awake()
    {
        //eventEmitterRefHeartBeat = GetComponent<StudioEventEmitter>();
         //MenuMusic = RuntimeManager. CreateInstance("event:/Music/Menu");
         //startMenuMusic();
        //eventEmitterRefThunder = GetComponent<StudioEventEmitter>();
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void playHeartSFX(/*int amountfear*/)
    {
        if (this.fear.fear > fear.getFearStart() && fear.fear < fear.getFearLow() - 0.01)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 0f);
            //Debug.Log("heartbeat Speed VLOW");
        }
        else if (fear.fear >= fear.getFearLow() && fear.fear < fear.getFearLowMedium() - 0.01)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 1f);
           // Debug.Log("heartbeat Speed LOW");
        }
        else if (fear.fear >= fear.getFearLowMedium() && fear.fear < fear.getFearMedium()-0.01)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 2f);
           // Debug.Log("heartbeat Speed LMEDIUM");
        }
        else if (fear.fear >= fear.getFearMedium() && fear.fear < fear.getFearHighMedium() - 0.01)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 3f);
           // Debug.Log("heartbeat Speed MEDIUM");
        }
        else if (fear.fear >= fear.getFearHighMedium() && fear.fear < fear.getFearHigh() - 0.01)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 4f);
           // Debug.Log("heartbeat Speed HMEDIUM");
        }
        else if (fear.fear >= fear.getFearHigh() && fear.fear < fear.getFearPanic() - 0.01)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 5f);
           // Debug.Log("heartbeat Speed HIGH");
        }
        else if (fear.fear >= fear.getFearPanic())
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 6f);
            eventEmitterRefAmbientIngameMusic.SetParameter(Constants.AMOUNTMENTALILLNESS, 1);
           // Debug.Log("heartbeat Speed VHIGH");
        }
        eventEmitterRefHeartBeat.Play();
    }

    public void playAmbientInGame(){
        eventEmitterRefAmbientIngameMusic.SetParameter(Constants.AMOUNTMENTALILLNESS, 0);
        eventEmitterRefAmbientIngameMusic.Play();
    }

    public void GameOverAmbientInGame()
    {
        //TODO
        eventEmitterRefAmbientIngameMusic.Stop();
    }

   /* public void startMenuMusic()
    {
        MenuMusic.start();
    }*/

    public void StopMenuMusic()
    {
        eventEmitterRefMenuMusic.Stop();
    }

    public void playDoorCreak(bool openclose)
    {
        //TODO: RANDOM DOOR SOUND
        if (openclose == false)
        {
            eventEmitterRefDoorOPENCreak.Play();
        }
        else
        {
            eventEmitterRefDoorCLOSECreak.Play();
        }
    }
}
