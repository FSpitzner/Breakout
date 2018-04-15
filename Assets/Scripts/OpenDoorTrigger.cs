using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTrigger : Trigger {

	public DoorOpener door;

	public override void Interact(){
		door.Open ();
	}
}
