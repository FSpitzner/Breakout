using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTrigger : InteractTrigger{

	public DoorOpener door;

	void Start(){
		triggerType = "Interact";
	}

	public override void Interact(){
		door.Open ();
	}
}