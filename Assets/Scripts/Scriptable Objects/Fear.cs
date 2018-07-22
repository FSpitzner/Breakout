using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Fear : ScriptableObject {
    [Tooltip("The current amount of Amy's fear")]
    public float fear;
    [Tooltip("The amount of Fear needed to switch to the Dreamworld")]
    public float fearDreamworldActivateValue;
    [Tooltip("The amount of Fear needed to deactivate the Dreamworld once activated")]
    public float fearDreamworldDeactivateValue;
    [Tooltip("The amount of Fear needed to Trigger the Panic Attack")]
    public float fearPanicAttack;

    private bool dreamworldActive;

    public GameEvent onDreamworldEnter;
    public GameEvent onDreamworldExit;
    public UnityEvent onPanicAttack;

    public void IncreaseFear(float amount)
    {
        fear += amount;
        CheckFearAmount();
    }

    private void CheckFearAmount()
    {
        if(fear >= fearDreamworldActivateValue)
        {
            dreamworldActive = true;
            onDreamworldEnter.Raise();
        }
        if(fear >= fearPanicAttack)
        {
            onPanicAttack.Invoke();
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
}
