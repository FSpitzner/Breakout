using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : Trigger{

    protected PlayerController player;

    public virtual void Interact()
    {
        Debug.LogWarning("This Trigger has no Interact Method!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.GetComponent<PlayerController>();
            player.RegisterInteractionTrigger(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            player.UnregisterInteractionTrigger(this);
            player = null;
        }
    }
}