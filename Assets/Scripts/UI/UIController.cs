using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject[] uiButtons;
    public GameObject[] uiQuestPanels;


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
}
