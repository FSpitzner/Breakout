using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTutorial : QuestController
{
    public GameObject tutorialPanel;
    public QuestController nextQuest;
    private bool gotCompanion = false, gotBackpack = false;

    private void Start()
    {
        LevelController.instance.RegisterQuestController(this);
    }

    public override void SetValue(int obj, bool state)
    {
        switch (obj)
        {
            case 0:
                gotCompanion = state;
                break;
            case 1:
                gotBackpack = state;
                break;
            default:
                break;
        }
        CheckWinState();
    }
	
    private void CheckWinState()
    {
        if(gotCompanion && gotBackpack)
        {
            nextQuest.enabled = true;
            this.enabled = false;
        }
    }
}
