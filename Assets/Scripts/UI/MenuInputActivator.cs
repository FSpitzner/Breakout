﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuInputActivator : MonoBehaviour {

    public StandaloneInputModule inputModule;
	
    public void EnableMenuInputs(bool state)
    {
        Debug.Log("Setting Menu Inputs to " + state);
        inputModule.enabled = state;
        Debug.Log("Menu Inputs are now " + inputModule.enabled);
    }
}