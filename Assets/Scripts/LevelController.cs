using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	[Header("General Settings")]
	public PlayerController player;
	public float fearMeterCheckInterval = 2;
	public static LevelController instance;
	private List<Trigger> interactTrigger;
	private List<Trigger> environmentTrigger;

	[Header("Fear Settings")]
	public int fearDreamworldTrigger;
	public int fearTriggerIncrease;
	public int fearTriggeredDecrease;
	private bool dreamworldTriggered = false;
	private int fear;

	[Header("Dreamworld Settings")]
	public DreamworldObject[] dreamworld;

	void Awake(){
		instance = this;
	}

	void Start(){
		interactTrigger = new List<Trigger> ();
		environmentTrigger = new List<Trigger> ();
		Invoke ("FearMeter", 1);
	}

	private void FearMeter(){
		if (environmentTrigger.Count != 0) {
			foreach (EnvironmentTrigger t in environmentTrigger) {
				fear += t.fearPower;
			}
		}
		if (dreamworldTriggered) {
			fear -= fearTriggeredDecrease;
		}
		CheckDreamworld ();
		Invoke ("FearMeter", fearMeterCheckInterval);
	}

	public void RegisterTrigger(Trigger trigger){
		Debug.Log ("Trigger entered: " + trigger + " | Triggertyp: " + trigger.GetTriggerType());
		if (trigger.GetTriggerType().CompareTo ("Interact") == 0) {
			this.interactTrigger.Add (trigger);
			Debug.Log (trigger + " is registered");
		}else if (trigger.GetTriggerType().CompareTo ("Environment") == 0){
			this.environmentTrigger.Add (trigger);
			Debug.Log (trigger + " is registered");
		}
	}

	public void UnregisterTrigger(Trigger trigger){
		if (trigger.GetTriggerType().CompareTo ("Interact") == 0) {
			if (this.interactTrigger.Contains (trigger)) {
				Debug.Log (trigger + " is not longer registered");
				this.interactTrigger.Remove (trigger);
			}
		} else if (trigger.GetTriggerType().CompareTo ("Environment") == 0) {
			if (this.environmentTrigger.Contains (trigger)) {
				this.environmentTrigger.Remove (trigger);
				Debug.Log (trigger + " is not longer registered");
			}
		}
	}

	public void UseTriggerObject(){
		if (interactTrigger.Count != 0)
			foreach (Trigger t in interactTrigger) {
				t.Interact ();
			}
	}

	private void CheckDreamworld(){
		if (fear >= fearDreamworldTrigger && !dreamworldTriggered) {
			fear += fearTriggerIncrease;
			dreamworldTriggered = true;
			foreach (DreamworldObject obj in dreamworld) {
				obj.Activate ();
			}
		} else if(fear < 0 && dreamworldTriggered){
			foreach (DreamworldObject obj in dreamworld) {
				obj.Deactivate ();
			}
			fear = 0;
			dreamworldTriggered = false;
		}
		Debug.Log ("Fear now at: " + fear);
	}

	public void ChangeFearBy(int amount){
		fear += amount;
	}

	public void IncreaseFear(int amount){
		fear += amount;
	}

	public bool GetDreamworldTriggered(){
		return dreamworldTriggered;
	}
}