using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController instance;
	public Trigger trigger;

	void Awake(){
		instance = this;
	}

	public void RegisterTrigger(Trigger trigger){
		this.trigger = trigger;
		Debug.Log (trigger + " is registered");
	}

	public void DeregisterTrigger(Trigger trigger){
		if (this.trigger == trigger) {
			Debug.Log (trigger + " is not longer registered");
			this.trigger = null;
		}
	}

	public void UseTriggerObject(){
		if(trigger != null)
			trigger.Interact ();
	}
}
