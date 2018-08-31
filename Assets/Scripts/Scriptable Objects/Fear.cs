﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Scriptable Objects/Fear")]
public class Fear : ScriptableObject {
    [Tooltip("The current amount of Amy's fear")]
    public float fear;
    [Tooltip("The amount of Fear needed to switch to the Dreamworld")]
    public float fearDreamworldActivateValue;
    [Tooltip("The amount of Fear needed to deactivate the Dreamworld once activated")]
    public float fearDreamworldDeactivateValue;
    [Tooltip("The amount of Fear needed to Trigger the Panic Attack")]
    public float fearPanicAttack;

    public float fearEventEnterThreshold;
    public float fearEventExitThreshold;
    private bool fearEventActive = false;

    private bool dreamworldActive;

    public GameEvent onDreamworldEnter;
    public GameEvent onDreamworldExit;
    public GameEvent onFearEnter;
    public GameEvent onFearExit;
    public GameEvent onPanicAttack;

    [Header("Heartbeat")]
    [Tooltip("The lower values for the starting point of the respecting heartbeat in %")]
    public int start;
    public int low; 
    public int lowMedium;
    public int medium;
    public int highMedium;
    public int high;
    public int panic;

    public void IncreaseFear(float amount)
    {
        fear += amount;
        if (fear <= 0)
        {
            fear = 0;
        }else if(fear >= fearPanicAttack)
        {
            fear = fearPanicAttack;
        }
        CheckFearAmount();
    }

    public void SetFearTo(float amount)
    {
        fear = amount;
        CheckFearAmount();
    }

    private void CheckFearAmount()
    {
        if (fear >= fearPanicAttack)
        {
            onPanicAttack.Raise();
        }
        else if (fearEventActive && fear <= fearEventExitThreshold)
        {
            onFearExit.Raise();
            fearEventActive = false;
        }
        else if (fear >= fearEventEnterThreshold && !fearEventActive)
        {
            onFearEnter.Raise();
            fearEventActive = true;
        }
        else if (fear >= fearDreamworldActivateValue && !IsDreamworldActive())
        {
            dreamworldActive = true;
            onDreamworldEnter.Raise();
        }
        if(IsDreamworldActive() && fear <= fearDreamworldDeactivateValue)
        {
            dreamworldActive = false;
            onDreamworldExit.Raise();
        }
    }

    public bool IsDreamworldActive()
    {
        return dreamworldActive;
    }
    
    /*public float getFearStart()
    {
        //return fearPanicAttack * (start / 100);
        return start;
    }
    public float getFearLow()
    {
        //return fearPanicAttack * (low / 100);
        return low;
    }
    public float getFearLowMedium()
    {
        //return fearPanicAttack * (lowMedium / 100);
        return lowMedium;
    }
    public float getFearMedium()
    {
        //return fearPanicAttack * (medium / 100);
        return medium;
    }
    public float getFearHighMedium()
    {
        //return fearPanicAttack * (highMedium / 100);
        return highMedium;
    }
    public float getFearHigh()
    {
        return high;
        //return fearPanicAttack * (high / 100);
    }
    public float getFearPanic()
    {
        //return fearPanicAttack * (panic / 100);
        return panic;
    }*/
    
}
