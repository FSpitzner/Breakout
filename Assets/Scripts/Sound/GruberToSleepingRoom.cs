using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class GruberToSleepingRoom : MonoBehaviour {
    public StudioEventEmitter GruberToSleepingroom;
    public StudioEventEmitter GruberSleepingroomMusic;

    private bool alreadytried = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        if(!alreadytried){
            GruberToSleepingroom.Play();
            GruberSleepingroomMusic.Play();
                alreadytried=true;
        }
        
    }

}
