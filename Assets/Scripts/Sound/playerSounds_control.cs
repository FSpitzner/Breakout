using System.Collections;
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
    public StudioEventEmitter eventEmitterRefDreamWorldMusic;
    public StudioEventEmitter eventEmitterRefSigh;
    //public StudioEventEmitter eventEmitterRefDoorOPENCreak;
    //public StudioEventEmitter eventEmitterRefDoorCLOSECreak;

    public EventInstance MenuMusic;
    public Fear fear;

    private bool MenuMusicPlaybackState;


    [Header("Sounds - Event Paths")]
    public string backpackEvent;
    public string deathEvent;
    public string sighEvent;
   /* public string doorCloseEvent;
    public string doorOpenEvent;*/

    private int i = 1;


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
        if (this.fear.fear > fear.start && fear.fear < fear.low-1)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 0f);
           // Debug.Log("heartbeat Speed VLOW");
        }
        else if (fear.fear >= fear.low && fear.fear < fear.lowMedium-1 - 0.01)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 1f);
            //Debug.Log("heartbeat Speed LOW");
        }
        else if (fear.fear >= fear.lowMedium && fear.fear < fear.medium-1)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 2f);
            //Debug.Log("heartbeat Speed LMEDIUM");
        }
        else if (fear.fear >= fear.medium && fear.fear < fear.highMedium-1)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 3f);
            //Debug.Log("heartbeat Speed MEDIUM");
        }
        else if (fear.fear >= fear.highMedium && fear.fear < fear.high-1)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 4f);
            eventEmitterRefDreamWorldMusic.SetParameter(Constants.AMOUNTMENTALILLNESS, 1);
            //Debug.Log("heartbeat Speed HMEDIUM");
        }
        else if (fear.fear >= fear.high && fear.fear < fear.panic-1)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 5f);
            eventEmitterRefDreamWorldMusic.SetParameter(Constants.AMOUNTMENTALILLNESS, 2);
            //Debug.Log("heartbeat Speed HIGH");
        }
        else if (fear.fear >= fear.panic)
        {
            eventEmitterRefHeartBeat.SetParameter(Constants.HEARTSPEED, 6f);
            eventEmitterRefDreamWorldMusic.SetParameter(Constants.AMOUNTMENTALILLNESS, 3);
            //eventEmitterRefAmbientIngameMusic.SetParameter(Constants.AMOUNTMENTALILLNESS, 1);
            //Debug.Log("heartbeat Speed VHIGH");
        }
        eventEmitterRefHeartBeat.Play();

      
    }

    public void startDreamworld()
    {
        eventEmitterRefDreamWorldMusic.Play();
        eventEmitterRefAmbientIngameMusic.Stop();
    }

    public void stopDreamworld()
    {
        eventEmitterRefAmbientIngameMusic.Play();
        eventEmitterRefDreamWorldMusic.Stop();
    }




    public void playAmbientInGame(){
        eventEmitterRefAmbientIngameMusic.SetParameter(Constants.AMOUNTMENTALILLNESS, 0);
        eventEmitterRefAmbientIngameMusic.Play();
    }



    public void GameOverWin()
    {
        if (fear.IsDreamworldActive())
            eventEmitterRefDreamWorldMusic.Stop();
        else
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

    /*public void playDoorCreak(bool openclose)
    {
        //TODO: RANDOM DOOR SOUND
        if (openclose == false)
        {
            RuntimeManager.PlayOneShot(doorOpenEvent);
            //eventEmitterRefDoorOPENCreak.Play();
        }
        else
        {
            RuntimeManager.PlayOneShot(doorCloseEvent);
            //eventEmitterRefDoorCLOSECreak.Play();
        }
    }*/

    public void playBackPack()
    {
        RuntimeManager.PlayOneShot(backpackEvent);
    }

    public void playDeath() {
        RuntimeManager.PlayOneShot(deathEvent);
    }

    public void playSigh() {
        eventEmitterRefSigh.Play();
    }

    

    
}
