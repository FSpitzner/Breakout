using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPrologController : QuestController {

    [Header("Quest Items")]
    [Tooltip("UI-Graphics-Panel for Keys")]
    public GameObject uikeys;
    public GameEvent winEvent;

    private bool gotBread = false, gotFlashlight = false, gotKeys = false;
    
    public override void CheckQuestObject(Object obj)
    {
        if(obj.GetType() == typeof(DoorOpener))
        {
            DoorOpener door = (DoorOpener)obj;
            if(door.questID == 1)
            {
                if (gotKeys)
                {
                    WIN();
                }
                else
                {
                    uikeys.SetActive(true);
                }
            }
        }
    }

    private bool CheckWinState()
    {
        Debug.Log("Test: Bread: " + gotBread + " , Flashlight: " + gotFlashlight + " , Keys: " + gotKeys);
        if(gotBread && gotFlashlight && gotKeys)
        {
            Debug.Log("Test done");
            return true;
        }
        return false;
    }

    private void WIN()
    {
        // TODO: Show Outro
        winEvent.Raise();
        Debug.Log("WIN");
        
    }

    public override void SetItem(Object obj)
    {
        switch (((ItemController)obj).itemID)
        {
            case 0:
                gotBread = true;
                break;
            case 1:
                gotFlashlight = true;
                break;
            case 2:
                gotKeys = true;
                break;
            default:
                break;
        }
        CheckWinState();
    }
}
