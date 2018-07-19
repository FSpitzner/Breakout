using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    
	[Header("General Settings")]
    [Tooltip("Insert Player-GameObject here")]
    public PlayerController player;
    [Tooltip("Interval in which changes to the Fear-Value are made in Seconds")]
    public float fearMeterCheckInterval = 2;
    public static LevelController instance;
    private List<Trigger> interactTrigger;
    private List<Trigger> environmentTrigger;
    //------------
    private List<Trigger> thunderTrigger;
    //------------
    private bool gameOver = false;
    public GameMenuController menuController;
    public CameraPointing cameraPointingSkript;
    private QuestController quest;

    [Header("Fear Settings")]
    [Tooltip("Fear-Value at which Dreamworld gets Triggered")]
    public int fearDreamworldTrigger;
    [Tooltip("Amount of Fear-decrease per Interval-Check when Dreamworld is Triggered")]
	public int fearTriggeredDecrease;
    [Tooltip("The Amount of Fear needed for the panic attack (Game Over)")]
    public int panicFearLevel;
	private bool dreamworldTriggered = false;
	private int fear;
    //public int fear;

	[Header("Dreamworld Settings")]
    [Tooltip("Put in every Dreamworld-Object of the Level here. They get Activated when the Dreamworld gets Triggered")]
	public DreamworldObject[] dreamworld;
    [Tooltip("Put in Amy's Companion here")]
    public CompanionController companion;

    private float pulseSpeed = 0f;
    private bool gameStarted = false;
    

    [Header("PlayerSoundSystem")]
    public playerSounds_control playerSoundSystem;
    //FOR TEST ONLY
    int thundersize;
   

	void Awake(){
		instance = this;
        
	}

	void Start(){
        if(menuController != null)
        {
            menuController.gameObject.SetActive(true);
        }
		interactTrigger = new List<Trigger> ();
		environmentTrigger = new List<Trigger> ();
        thunderTrigger = new List<Trigger>();
		Invoke ("FearIntervalCheck", 1);
	}

	private void FearIntervalCheck(){
        fear -= fearTriggeredDecrease;
        if (environmentTrigger.Count != 0) {
			foreach (EnvironmentTrigger t in environmentTrigger) {
				fear += t.fearPower;
			}
		}
        if(fear >= panicFearLevel)
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }

        if(fear < 0)
        {
            fear = 0;
        }
		CheckDreamworld ();
		Invoke ("FearIntervalCheck", fearMeterCheckInterval);
	}

    private void Update()
    {
        if (gameStarted) { 
            if (gameOver)
            {
                if(Input.GetKey("joystick button 0"))
                {
                    gameOver = false;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
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
        else if (trigger.GetTriggerType().CompareTo("Thunder") == 0)
        {
            this.thunderTrigger.Add(trigger);
            System.Random randomIntForThunder = new System.Random();
            thundersize= randomIntForThunder.Next(0,1);
            playerSoundSystem.playThunder(thundersize);
            Debug.Log(trigger + " is registered");
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
        else if (trigger.GetTriggerType().CompareTo("Thunder") == 0)
        {
            if (this.thunderTrigger.Contains(trigger))
            {
                this.thunderTrigger.Remove(trigger);
                Debug.Log(trigger + " is not longer registered");
            }
        }
	}

	public void UseTriggerObject(){
		if (interactTrigger.Count != 0)
			foreach (Trigger t in interactTrigger) {
				t.Interact ();
			}
	}

    private void CheckDreamworld()
    {
        if (fear >= fearDreamworldTrigger && !dreamworldTriggered)
        {
            dreamworldTriggered = true;
            companion.transform.position = companion.companionTargetAmy.transform.position;
            foreach (DreamworldObject obj in dreamworld)
            {
                obj.Activate();
            }
            companion.SetActive(true);
        }
        else if (fear <= 0 && dreamworldTriggered)
        {
            foreach (DreamworldObject obj in dreamworld)
            {
                obj.Deactivate();
            }
            companion.SetActive(false);
            dreamworldTriggered = false;
        }
        Debug.Log("Fear now at: " + fear);


        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
         *'''''####'''''''####'''''###''###'''####'''''###'''#########'''''*
         *'''###''###'''###''###'''###''###'''#####''''###'''###''''###''''*
         *''''###'''''''###''###'''###''###'''###'##'''###'''###'''''###'''*
         *''''''###'''''###''###'''###''###'''###''##''###'''###'''''###'''*
         *''''''''###'''###''###'''###''###'''###'''##'###'''###'''''###'''*
         *'''###''###'''###''###'''###''###'''###''''#####'''###''''###''''*
         *'''''####'''''''####'''''''####'''''###'''''####'''#########'''''*
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        
        
        //SOUND - checkingFEAR
        playerSoundSystem.setfearamount(fear);
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

    public void StartGame()
    {
        gameStarted = true;
        player.StartGame();
    }

    public GameMenuController GetGameMenuController()
    {
        return menuController;
    }

    public void InformCameraPointing()
    {
        cameraPointingSkript.CameraOnPos();
    }

    public void RegisterQuestController(QuestController qc)
    {
        quest = qc;
    }

    public QuestController getQuest()
    {
        return quest != null ? quest : null;
    }

    public int GetFear()
    {
        return fear;
    }
}