using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject[] uiButtons;
    public GameObject[] uiQuestPanels;
    public GameObject cameraSwitchFadeObject;
    public GameObject menuCamera;
    public GameEvent readyToPlayEvent;


    public void ToggleUI(bool enabled)
    {
        foreach (GameObject o in uiButtons)
        {
            o.SetActive(enabled);
        }

    }

    public void ToggleQuestUI(bool enabled)
    {
        foreach(GameObject o in uiQuestPanels)
        {
            o.SetActive(enabled);
        }
    }

    public void Fadeout()
    {
        cameraSwitchFadeObject.SetActive(true);
        Invoke("SwitchCamera", 1f);
    }

    public void GameStart()
    {
        Invoke("Fadeout", 5.5f);
    }

    private void SwitchCamera()
    {
        menuCamera.SetActive(false);
        readyToPlayEvent.Raise();
    }
}
