using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIActiveButtonWaiter : MonoBehaviour {

    public GameObject acitveObject;
    public EventSystem eventSystem;
    
    public void DelayedSelection(Object obj)
    {
        eventSystem.SetSelectedGameObject(acitveObject);
    }
}
