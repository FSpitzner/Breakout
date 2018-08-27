using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTrigger : Trigger {

    public FearTriggerType type;
    public Fear fear;

    protected bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player hat " + gameObject.name + " betreten");
            isInside = true;
            FearTick();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player hat " + gameObject.name + " verlassen");
            isInside = false;
        }
    }

    private void FearTick()
    {
        if (isInside)
        {
            fear.IncreaseFear(type.fearPowerPerTick);
            Invoke("FearTick", type.GetTickTime());
        }
    }
}