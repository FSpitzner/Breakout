using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterEventShooter : MonoBehaviour {

    public RegisterEvent Event;
    public Object registeredObject;
    //public bool shootEventOnEnable = false;
    /*
    private void OnEnable()
    {
        Debug.Log("Registering Event");
        Event.RegisterShooter(this);
    }
*/
    private void Awake()
    {
        this.enabled = true;
    }
/*
    private void OnDisable()
    {
        Event.UnregisterShooter();
    }
    */
    public void RaiseEvent()
    {
        Event.GetListeners().ForEach((RegisterEventListener rel) =>
        {
            rel.OnEventRaised(registeredObject);
        });
    }
}
