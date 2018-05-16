using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Dieser Trigger wird verwendet um einen Türöffner auszulösen.
 * Er hat den Triggertyp "Interact".
*/

public class OpenDoorTrigger : InteractTrigger{

	public DoorOpener door;

	void Start(){
		triggerType = "Interact";
	}

	public override void Interact(){
		door.Open ();
	}
}