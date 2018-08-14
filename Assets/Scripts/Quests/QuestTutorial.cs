using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTutorial : QuestController
{
    public GameObject tutorialPanel;
    public DoorOpener door;
    public QuestController nextQuest;
    private bool gotFlower = false, gotBackpack = false;

    private void Start()
    {
        LevelController.instance.RegisterQuestController(this);
    }

    public override void SetValue(int obj, bool state)
    {
        switch (obj)
        {
            case 3:
                gotFlower = state;
                break;
            case 4:
                gotBackpack = state;
                break;
            default:
                break;
        }
        CheckWinState();
    }
	
    private void CheckWinState()
    {
        if(gotFlower && gotBackpack)
        {
            door.doorIsLocked = false;
            nextQuest.enabled = true;
            this.enabled = false;
        }
    }

    public void SetItem(object obj)
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
