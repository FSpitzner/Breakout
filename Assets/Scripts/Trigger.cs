using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	void OnTriggerEnter(){
		LevelController.instance.RegisterTrigger (this);
	}

	void OnTriggerExit(){
		LevelController.instance.DeregisterTrigger (this);
	}

	public virtual void Interact(){
		Debug.LogWarning ("This Trigger has no Interact Method!");
	}
}
