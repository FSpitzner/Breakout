using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTutorial : QuestController
{
    public GameEvent completeEvent;
    public DoorOpener door;
    public QuestController nextQuest;
    private bool gotFlower = false, gotBackpack = false;
	
    private void CheckWinState()
    {
        if(gotFlower && gotBackpack)
        {
            door.doorIsLocked = false;
            nextQuest.enabled = true;
            this.enabled = false;
            completeEvent.Raise();
        }
    }

    public override void SetItem(Object obj)
    {
        switch (((ItemController)obj).itemID)
        {
            case 3:
                gotFlower = true;
                break;
            case 4:
                gotBackpack = true;
                break;
            default:
                break;
        }
        CheckWinState();
    }
}
