using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    [Header("General Settings")]
    [Tooltip("Insert Player-GameObject here")]
    public PlayerController player;
    public static LevelController instance;
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
    [Tooltip("Amount of Fear added per Tick. Use negative Amounts here")]
    public float fearPerTick = -0.2f;
    [Tooltip("Amount of Ticks per Second")]
    public float ticksPerSecond = 5f;

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

    [Header("Weather")]
    [Tooltip("Thunderstorm?")]
    public bool thunderstorm = false;
    [HideInInspector]
    [Tooltip("Insert Thunderstorm Controller here")]
    public ThunderstormController thunderstormController;


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
	}

    private void FearTick()
    {
        fear.IncreaseFear(fearPerTick);
        Invoke("FearTick", 1 / ticksPerSecond);
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
        if(fear.fear <= 0)
        {
            fear.fear = 0f;
        }else if(fear.fear >= fear.fearPanicAttack)
        {
            fear.fear = fear.fearPanicAttack;
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
        Invoke("FearTick", 1 / ticksPerSecond);
        if(thunderstorm)
            thunderstormController.StartThunderstorm();
        //player.StartGame();
    }

    public GameMenuController GetGameMenuController()
    {
        return menuController;
    }

    public void RegisterQuestController(QuestController qc)
    {
        quest = qc;
    }

    public QuestController getQuest()
    {
        return quest != null ? quest : null;
    }

    private void OnApplicationQuit()
    {
        List<StageController> stages = new List<StageController>();
        stages = GetStageController(transform, stages);
        stages.ForEach((StageController sc) => {
            sc.OnQuit();
        });
    }

    private List<StageController> GetStageController(Transform parent, List<StageController> stages)
    {
        if(parent.GetComponent<StageController>() != null)
        {
            stages.Add(parent.GetComponent<StageController>());
        }
        else
        {
            foreach(Transform child in parent)
            {
                GetStageController(child, stages);
            }
        }
        return stages;
    }
}

[CustomEditor(typeof(LevelController))]
[CanEditMultipleObjects]
public class LevelControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        LevelController script = (LevelController)target;
        if (script.thunderstorm)
        {
            script.thunderstormController =
                EditorGUILayout.ObjectField("Thunderstorm Controller", script.thunderstormController, typeof(ThunderstormController), true) as ThunderstormController;
        }
        else
        {
            script.thunderstormController = null;
        }
    }
}