using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandupInhibitor : Trigger {
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.attachedRigidbody.GetComponent<PlayerController>().canStandup = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.attachedRigidbody.GetComponent<PlayerController>().canStandup = true;
        }
    }
}
