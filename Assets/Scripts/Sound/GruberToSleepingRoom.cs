using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class GruberToSleepingRoom : MonoBehaviour {
    public string GruberToSleepingroomEventPath;
    public StudioEventEmitter GruberSleepingroomMusic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        RuntimeManager.PlayOneShot(GruberToSleepingroomEventPath);
        GruberSleepingroomMusic.Play();
    }

}
