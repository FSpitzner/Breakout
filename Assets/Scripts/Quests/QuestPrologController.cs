using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPrologController : QuestController {

    [Header("Quest Items")]
    [Tooltip("UI-Graphics-Panel for Keys")]
    public GameObject uikeys;



    private bool gotBread = false, gotFlashlight = false, gotKeys = false;

    private void Start()
    {
        LevelController.instance.RegisterQuestController(this);
    }

    public override void CheckQuestObject(Object obj)
    {
        if(obj.GetType() == typeof(DoorOpener))
        {
            DoorOpener door = (DoorOpener)obj;
            if(door.questID == 1)
            {
                uikeys.SetActive(true);
            }
        }
    }

    public override void SetValue(int obj, bool state)
    {
        switch (obj)
        {
            case 0:
                gotBread = state;
                break;
            case 1:
                gotFlashlight = state;
                break;
            case 2:
                gotKeys = state;
                break;
            default:
                break;
        }
        CheckWinState();
    }

    private void CheckWinState()
    {
        Debug.Log("Test: Bread: " + gotBread + " , Flashlight: " + gotFlashlight + " , Keys: " + gotKeys);
        if(gotBread && gotFlashlight && gotKeys)
        {
            Debug.Log("Test done");
            WIN();
        }
    }

    private void WIN()
    {
        // TODO: Show Outro

        Debug.Log("WIN");
        
    }
}
