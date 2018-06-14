using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	[Header("General Settings")]
    [Tooltip("Insert Player-GameObject here")]
	public PlayerController player;
    [Tooltip("Interval in which changes to the Fear-Value are made in Seconds")]
	public float fearMeterCheckInterval = 2;
	public static LevelController instance;
	private List<Trigger> interactTrigger;
	private List<Trigger> environmentTrigger;

	[Header("Fear Settings")]
    [Tooltip("Fear-Value at which Dreamworld gets Triggered")]
    public int fearDreamworldTrigger;
    [Tooltip("Amount of Fear that gets added when Dreamworld gets Triggered (Maybe Obsolete)")] //TODO: Check ob noch gebraucht
	public int fearTriggerIncrease;
    [Tooltip("Amount of Fear-decrease per Interval-Check when Dreamworld is Triggered")]
	public int fearTriggeredDecrease;
	private bool dreamworldTriggered = false;
	private int fear;

	[Header("Dreamworld Settings")]
    [Tooltip("Put in every Dreamworld-Object of the Level here. They get Activated when the Dreamworld gets Triggered")]
	public DreamworldObject[] dreamworld;
    [Tooltip("Put in Amy's Companion here")]
    public CompanionController companion;

    private float pulseSpeed = 0f;


    [Header("PlayerSoundSystem")]
    public playerSounds_control playerSoundSystem;

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
            companion.SetActive(true);
		} else if(fear < 0 && dreamworldTriggered){
			foreach (DreamworldObject obj in dreamworld) {
				obj.Deactivate ();
			}
            companion.SetActive(false);
			fear = 0;
			dreamworldTriggered = false;
		}
		Debug.Log ("Fear now at: " + fear);
	
     //SOUND - checkingFEAR
        if(fear > 0){
            playerSoundSystem.hasfear();
        }else{
            playerSoundSystem.hasNOfear();
            pulseSpeed = 0f;
        }

        if (fear > 0 && fear <=10)
        {
            playerSoundSystem.fearLevelLow();
            pulseSpeed = 1.3f;
        }
        else if (fear > 10 && fear <= 20){
            playerSoundSystem.fearLevelMedium();
            pulseSpeed = 0.75f;
        }else if (fear > 20)
        {
            playerSoundSystem.fearLevelHigh();
            pulseSpeed = 0.48f;
        }
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

    public bool IsDreamworldTriggered()
    {
        return dreamworldTriggered;
    }

    public float getPulseSpeed()
    {
        return pulseSpeed;
    }
}