using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTrigger : Trigger {

    public FearTriggerType type;
    public Fear fear;

    protected bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Player hat mich betreten");
        if (other.tag == "Player")
        {
            isInside = true;
            FearTick();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
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