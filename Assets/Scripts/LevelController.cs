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
    [Tooltip("The Fear Scriptable Object")]
    public Fear fear;
    [Tooltip("The value fear gets resetted to if resetFearOnStartToDefault is active")]
    public float defaultFear;
    [Tooltip("If active fear gets resetted to Default Fear on Game Start")]
    public bool resetFearOnStartToDefault;

    //public int fear;

	[Header("Dreamworld Settings")]
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
        if (resetFearOnStartToDefault)
        {
            fear.fear = defaultFear;
        }
	}

	void Start(){
        if(menuController != null)
        {
            menuController.gameObject.SetActive(true);
        }
		interactTrigger = new List<Trigger> ();
		environmentTrigger = new List<Trigger> ();
        thunderTrigger = new List<Trigger>();
	}

	/*private void FearIntervalCheck(){
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
	}*/

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

    private void CheckDreamworld()
    {
        
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
        //playerSoundSystem.setfearamount(fear);
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
}