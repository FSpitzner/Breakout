using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTrigger : Trigger {

	public int fearPower;

	void Start(){
		triggerType = "Environment";
	}
}