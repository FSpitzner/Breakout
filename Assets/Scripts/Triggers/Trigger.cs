using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	protected string triggerType;

	void OnTriggerEnter(){
		LevelController.instance.RegisterTrigger (this);
	}

	void OnTriggerExit(){
		LevelController.instance.UnregisterTrigger (this);
	}

	public virtual void Interact(){
		Debug.LogWarning ("This Trigger has no Interact Method!");
	}

	public string GetTriggerType(){
		return triggerType;
	}
}