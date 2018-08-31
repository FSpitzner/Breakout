using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;
using UnityEngine.Events;

public class RegisterEventListener : MonoBehaviour {

    public RegisterEvent Event;
    public int methodeID;
    public bool respondWithMethode = false;
    [Tooltip("Put the Target-Script in here")]
    [ConditionalHide("respondWithMethode", true)]
    public MonoBehaviour target;
    [ConditionalHide("respondWithMethode", true)]
    public MethodInfo targetMethode;
    public UnityEvent response;

    private void Start()
    {
        if (targetMethode == null && respondWithMethode)
            Debug.LogWarning("Attention! TargetMethode on " + gameObject.name + " not set!");
    }

    private void OnEnable()
    {
        Debug.Log("Event " + Event.name + " registered");
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Object registeredObject)
    {
        if (respondWithMethode)
        {
            Debug.Log("Registriere: " + registeredObject);

            MethodInfo[] methods = target.GetType().GetMethods();
            targetMethode = methods[methodeID];
            Debug.Log("Invoke Method: " + targetMethode);
            targetMethode.Invoke(
                target,
                new object[] { registeredObject });
        }
        response.Invoke();
    }
}

