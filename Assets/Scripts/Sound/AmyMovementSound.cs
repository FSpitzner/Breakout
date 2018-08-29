using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmyMovementSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void playMovement(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path);
    }
}
