using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/RegisterEvent")]
public class RegisterEvent : ScriptableObject {

    public List<RegisterEventListener> eventListeners = new List<RegisterEventListener>();
    //public RegisterEventShooter eventShooter;

    public List<RegisterEventListener> GetListeners()
    {
        return eventListeners;
        /*Debug.Log("RegisterEvent " + this + " got Raised with Object: " + obj);
        for(int i = eventListeners.Count -1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(obj);
        }*/
    }

    public void RegisterListener(RegisterEventListener listener)
    {
        eventListeners.Add(listener);
        //Debug.Log("Listener " + listener + "has tried to Register!\nRegistered Listeners: " + eventListeners.Count);
    }

    public void UnregisterListener(RegisterEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
    /*
    public void RegisterShooter(RegisterEventShooter shooter)
    {
        eventShooter = shooter;
        Debug.Log("Shooter " + eventShooter + " registered");
    }

    public void UnregisterShooter()
    {
        eventShooter = null;
        obj = null;
    }*/
}
